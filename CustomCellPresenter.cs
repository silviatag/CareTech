//
// Copyright (c) 2015, MindFusion LLC - Bulgaria.
//

using System;
using System.Windows;


namespace MindFusion.Scheduling.Wpf.Samples.CS.DualView
{
    public class CustomCellPresenter : CellPresenter
    {
        static CustomCellPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCellPresenter),
                new FrameworkPropertyMetadata(typeof(CustomCellPresenter)));
        }

        public CustomCellPresenter(Calendar calendar, Calendar schedule)
            : base(calendar)
        {
            schedule.ItemCreated += OnItemCreated;
            schedule.ItemModified += OnItemModified;
            schedule.ItemDeleted += OnItemDeleted;
        }

        private void OnItemCreated(object sender, ItemEventArgs e)
        {
            if (Intersects(e.Item))
                UpdateState();
        }

        private void OnItemModified(object sender, ItemModifiedEventArgs e)
        {
            if (Intersects(e.OldStartTime, e.OldEndTime) || Intersects(e.Item))
                UpdateState();
        }

        private void OnItemDeleted(object sender, ItemEventArgs e)
        {
            if (Intersects(e.Item))
                UpdateState();
        }

        protected override void OnEndTimeChanged(DateTime oldTime, DateTime newTime)
        {
            if (IsLoaded)
                UpdateState();

            base.OnEndTimeChanged(oldTime, newTime);
        }

        private bool Intersects(Item item)
        {
            return Intersects(StartTime, EndTime, item.StartTime, item.EndTime);
        }

        private bool Intersects(DateTime start, DateTime end)
        {
            return Intersects(StartTime, EndTime, start, end);
        }

        private static bool Intersects(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start2.Ticks < end1.Ticks && start1.Ticks < end2.Ticks;
        }

        private void UpdateState()
        {
            if (EndTime == DateTime.MinValue)
                return;

            if (Calendar.Schedule.GetAllItems(StartTime, EndTime.Subtract(TimeSpan.FromTicks(1))).Count > 0)
                FontWeight = FontWeights.ExtraBold;
            else
                FontWeight = FontWeights.Normal;
        }
    }
}
