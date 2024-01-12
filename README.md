# Clinic
## Project Description
Description: This Clinical System project is a C#-based application that includes four views for administrators, doctors, nurses, and receptionists. The system utilizes OCR and NLP technologies to streamline clinical operations. Administrators have the ability to manage user roles and permissions, as well as add doctors, nurses, and receptionists to the system. Doctors can access patient records, communicate with other doctors, and view upcoming appointments. Nurses can update patient information, collaborate with doctors, and perform nursing tasks. Receptionists are responsible for handling appointments, check-ins, and managing the front desk operations. OCR technology extracts relevant data from documents, while NLP technology analyzes unstructured text. The system also contains advanced AI features that help with disease prediction, prescription recommendations, and provide warnings for potential drug-to-disease interactions. It also incorporates a decision support system. These features facilitate efficient workflow, save time and space, and reduce medication errors and data loss. The primary goal of the system is to improve efficiency and enhance patient care by providing a comprehensive and user-friendly solution for clinical management.
## Key Features
1)  Storing patient data electronically
This feature provides a secure and efficient method for managing patient records. By transitioning from paper-based records to electronic storage, the clinic can easily access and update patient information, reducing the risk of data loss, misplacement, and errors.
2)	Appointment scheduling
This feature simplifies and enhances the process of booking and managing patient appointments. It enables the clinic personnel to efficiently organize their schedules and optimally allocate their time. 
3)	Queuing system 
This feature optimizes the waiting experience, ensuring that patients are served in an orderly and fair manner. It eliminates confusion and disputes, particularly for patients who temporarily leave the clinic and then return, as the system integrates them back into the queue.
4)	Prescription recommendations
This feature assists doctors by suggesting appropriate medications and treatment options based on patient-specific data and medical guidelines. 
5)	Disease Diagnosis
This feature assists doctors in making informed decisions, leading to better patient care. It streamlines the diagnostic process and reduces errors. 
6)	Warning System
This feature leverages real-time patient data and medical information to provide timely warnings and alarms to the clinic. It helps identify and address potential health issues or critical situations promptly, allowing for quick intervention and improved patient care. 
7)	Billing and financial system
 This functionality simplifies the billing process, making it more efficient and accurate. It allows for the management of patient payments and financial records. The billing and financial system ensures that the clinic's financial transactions are well-organized.
8)	Data analysis
This feature uses analytics and visualization tools to complex data into actionable insights. It allows clinic personnel and administrators to make data-driven decisions, enhancing patient care, operational efficiency, and financial management. 
9)	Connected user-friendly mobile app 
The user-friendly app allows patients to schedule appointments, access their medical records, and receive important notifications.
## Each view description
Admin: 
•	After opening the application, a sign-in screen should be displayed, and then the admin enters the email and password.
•	After opening the account, a homepage appears for the admin, showing the important points for the day such as the upcoming appointments.
•	On the navigation bar, the admin can add, modify, and delete the accounts for the doctors, receptionists, and nurses.
•	The admin can also configure system settings, such as appointments, billing rates, and user permissions.
•	The finance page is also viewed by the admin about clinic finances. 

Doctor:
•	After opening the application, a sign-in screen should be displayed, and then the doctor enters the email and password.
•	After opening the account, a homepage appears for the doctor, showing some of the upcoming appointments, the data analysis of the day, and the finances of the day.
•	On the navigation bar, the doctor can view the patients’ profile such as the overview information. 
•	Moreover, the doctor can access and update the patient records, including medical history and diagnosis.
•	The doctor can also prescribe medications and review patient prescriptions.
•	The doctor can also view their own appointment schedule and set the availability for the day.
•	The finance page is also viewed by the doctor about his own finances. 

Receptionist:
•	After opening the application, a sign-in screen should be displayed, and then the receptionist enters the email and password.
•	After opening the account, a homepage appears for the receptionist, showing some of the appointments, the check-in of patients when they arrive at the clinic, and the data analysis of the day. 
•	On the navigation bar, the receptionist can view the patient overview information, register new patients, and update contact information.
•	 The receptionist can schedule and manage patient appointments such as emergency cases.
•	The receptionist can generate invoices and process payments.



Nurse:
•	After opening the application, a sign-in screen should be displayed, and then the nurse enters the email and password.
•	After opening the account, a homepage appears for the nurse, showing the upcoming appointments and the data analysis of the day.
•	On the navigation bar, the nurse can overview patient information, and record vital signs and medical history.
•	The nurse can also manage the medical supplies and equipment.

## Front end pages and UML
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/7d324d83-7d3e-4e44-be4a-e62fa048c625" width="300">
<br>
Add Patient Page:
The "Add Patient" page in our clinical management system is shown to the receptionist in the case of adding a new patient. There is some information that needs to be taken from the patient to help in gaining an overview of the patient.
The first thing to be taken is the patient's name, followed by the date of birth, which the receptionist can choose from the calendar directly, automatically calculated age. The national ID, so later the receptionist can search for the patient using it as a unique identifier. The gender is a drop-down menu to make it easy for the receptionist to choose, as well as the blood group. Moreover, the phone number is taken from the patient if they need it later. The last thing is the patient status, so if the receptionist wants to add something extra or if there is health insurance.
The "Edit", "Save", and "Cancel" buttons are located at the bottom of the "Add Patient" page. The "Edit" button allows the patient to change their existing information. The "Save" button creates a new patient record in the system or updates an existing record. The "Cancel" button exits the page without saving any changes
</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/e91b6524-9da6-4bf3-9bd1-b5e9b6cb7313" width="300">
<br>
The equipments page where it shows all the equipments in the clinic and provides details about them
</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/c35d0f00-e4ea-45db-9f3e-c9943990209f" width="300">
<br>
Dr. Homepage.  It provides a centralized hub for accessing patient information, test results, medical records, and other essential data. Dr. Homepage, doctors can efficiently navigate through various modules, such as appointment scheduling, fees and patient case. When dr. Press on details button it will take him to the patient files. 
</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/ddf07e54-5f17-4f53-b975-f3da9aa24bcc" width="300">
<br>
Log In Page:
Every user will have a unique username and password to log in to his account when he clicks on the log in button and according to the username his specific view will appear.

</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/7956a159-83e7-47ef-a16f-c147dcd475aa" width="300">
<br>
Patient History Page:
The history page is accessible to the admin, receptionist, doctor, and nurse within the clinic’s system ensuring that relevant medical personnel can retrieve and update crucial patient information. It is initially completed upon the patient’s first arrival and serves as a comprehensive repository of the patient’s medical history. Its purpose is to document and store essential details about the patient's medical background.
The History page is organized into three distinct sections, each focusing on specific aspects of the patient's medical history:
Past and Present Medical Problems:
•	This section captures information about the patient's historical and current medical issues.
•	Questions within this section are answered by marking checkboxes relevant to the patient's specific medical conditions, such as high blood pressure or a history of heart attacks.




Present Medications and Allergies:
•	This section compiles details about the patient's current medications and any known allergies.
•	Specific allergy-related questions are included, such as allergies to penicillin, aspirin, or sulfa drugs.
Reviews of Systems:
•	The third section delves into an assessment of various body systems, including the endocrine and gastrointestinal systems.
•	System-specific questions aim to gather information about the patient's overall health and specific organ systems.
Question Types:
•	Questions within each section are designed as checkboxes, facilitating a straightforward process for healthcare professionals to record relevant information.
•	Examples include inquiries about high blood pressure, prior heart attacks, and allergies to specific medications.

</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/0fe8ced3-4229-49f9-b2cc-bd8f4931bb1d" width="300">
<br>
Analytics Page:
The data analysis page is a key feature accessible in the admin, doctor, and nurse views through the “Analytics” button located in the navigation bar on the left side of the program for easy access. Its main function is to provide a comprehensive overview of medical data and patient progress. It contains multiple charts that display this data.
Patients Progress Chart:
•	This chart visually represents the progress of patients over a specific timeline.
•	The chart serves as a valuable tool for checking whether patients are improving and shows the effectiveness of implemented medical approaches.
Patient Recovery Chart:
•	Following the Patients Progress Chart, there is a dedicated chart for displaying the average patient recovery and associated ratios.
•	This chart provides insights into the overall recovery trends, allowing the viewer to discern patterns and variations.
Test Results Chart:
•	Another feature is the "Test" chart, which displays the average test results of all patients.
•	The chart indicates the distribution of results on the scale, revealing whether they fall below, within, or above the normal range.
•	This visual representation aids in quickly identifying trends and abnormalities in test outcomes.
Frequently Used Medicine Chart:
•	The final component is the "Frequently Used Medicine" chart, designed to showcase the medications most commonly prescribed by doctors.
•	This chart offers valuable insights into the prevalence of specific medications in the treatment process.
•	By identifying frequently prescribed medications, it encourages doctors to delve deeper into studying and researching these drugs, fostering a continuous search for better alternatives.


</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/cb38e125-9173-464c-81da-86014ea424c2" width="300">
<br>
OCR page where the source document could be a scanned image or a photograph of printed or handwritten text. The OCR technology has converted the visual elements of the document into machine-readable text, allowing for digital storage, searchability, and editing
</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/d72bbef3-f84e-4e61-be04-eb4cae04949c" width="300">
<br>
Nurse home page
The nurse's homepage is a comprehensive dashboard designed to streamline and optimize the healthcare workflow. It provides a dynamic overview of the doctors available in the clinic, along with the specific types of appointments they offer. The interface offers real-time status updates on both doctors and patients, allowing the nurse to efficiently manage and coordinate medical care. A key feature of the homepage is the visibility into the number of bookings and sessions, offering insights into the clinic's overall activity. Additionally, the nurse can access detailed information about the current appointments, ensuring seamless coordination between medical professionals and patients. The inclusion of a calendar feature provides a convenient snapshot of upcoming appointments, complete with details such as the date, time, and the specific type of appointment scheduled. This nurse-centric homepage serves as a powerful tool for effective patient care coordination, enhancing communication, and promoting an organized and efficient healthcare environment.

</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/40ee799f-047d-4f99-9ef7-33b48a2a9caf" width="300">
<br>
The page provides the fees for a specific patient
</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/28f7466e-cbab-4262-975e-384cd425a314" width="300">
<br>
The patient integrated view offers healthcare professionals a comprehensive overview of a patient's medical history and current health status. It brings together information from various sources, including medical records, test results, medications, allergies, and treatment plans, into a centralized and easily accessible interface. Through the patient integrated view, doctors gain a holistic understanding of the patient's health, enabling them to make well-informed clinical decisions.
</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/f33f02f8-6eea-4ff0-8c48-3642a0858f68" width="300">
<br>
The prescription page facilitates the safe and efficient management of medication prescriptions for patients. It provides healthcare professionals with to prescribe and manage medications accurately. Within the prescription page, doctors can access comprehensive drug databases, including dosage information, potential interactions, and contraindications. This enables them to make informed decisions and select the most appropriate medications for their patients. Additionally, the prescription page often includes features to streamline the prescription workflow, such as electronic prescribing, automated drug-drug interaction checks, and allergy alerts. 
</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/3b259a0b-1373-4bbb-b3cb-e3d0c757a503" width="300">
<br>
The View Equipment page: It provides a comprehensive overview of equipment information and enables users to make necessary modifications to the data. Upon accessing the page, users are presented with a detailed breakdown of equipment specifications, including the equipment name ,  type, vendor, acquisition cost, and expected lifespan. This readily available information allows users to quickly grasp the essential details of each equipment asset.
To facilitate data modification, the page incorporates intuitive editing capabilities. Users can seamlessly update any of the equipment's attributes by simply clicking on the corresponding field and entering the desired changes. The editing process is streamlined, ensuring a user-friendly experience for all individuals accessing the page.
In instances where users decide not to make any alterations to the equipment data, they can effortlessly revert to the original information by clicking the "Cancel" button. This option provides users with the flexibility to maintain the existing data without any unnecessary modifications.
</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/588f1b44-9f8c-404f-9c85-d23df1d93825" width="300">
<br>
The "Settings" page in our system serves for users to customize and configure their preferences, enhancing their overall experience with the platform. This page has a variety of choices designed to specific user requirements.
The user can change the profile picture, the password, or the username. Moreover, if the user wants to request an absence day, choose the day and a drop-down menu for the reasons to take the absence day, then request the absence from the admin. Lastly, if there is something in the system the user wants to request access to, the drop-down menu for these accesses will have a request access button to send to the admin to accept it.
Finally, the "Settings" page is designed with a user-friendly interface, ensuring that users can easily navigate and configure their preferences. It contributes to a personalized and efficient user experience, allowing individuals to tailor the system to their unique requirements. 

</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/b9511692-ebd5-4816-a856-144f9776d6b0" width="300">
<br>
The patient data analysis page in that allows healthcare professionals to delve into and analyze patient data in a meaningful way. This page provides a range of analytical capabilities, such as generating charts, graphs, and reports based on patient demographics, diagnoses, treatments, and outcomes. By leveraging the patient data analysis page, healthcare providers can identify patterns, trends, and correlations, which can inform clinical decision-making, quality improvement initiatives, and research efforts. 
</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/23f759d0-28ca-44c4-ba0d-39984d9cf635" width="300">
<br>
Receptionist home page
The receptionist's homepage serves as a centralized hub for efficient management of patient interactions within the clinic. Featuring a user-friendly interface, the homepage boasts a prominent search button, allowing the receptionist to swiftly locate patients by name. Upon activation, this button generates a convenient dropdown menu presenting a comprehensive list of patients in the clinic. The interface also provides an appointment overview section, displaying key details such as the total number of appointments, the most recent appointment, and the upcoming appointment. This streamlined overview enables the receptionist to stay well-informed about the clinic's schedule. Moreover, the receptionist can seamlessly add new appointments through a dedicated function. For enhanced patient care, the homepage includes a contact details section, facilitating quick access to essential information. To ensure optimal communication and timely updates, the system is equipped with reminder features, notifying the receptionist of any changes or additions to the appointment schedule. This integrated and intuitive system empowers the receptionist to efficiently navigate patient information and maintain a well-organized appointment workflow.

</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/2da8a649-c0a7-4741-ab36-582c4d6caf85" width="300">
<br>
The Add Equipment page provides a convenient platform for entering new equipment information into the system. Upon accessing the page, users are presented with a structured form that captures all the necessary details about the equipment. This includes fields for the operating system name, equipment type, vendor, acquisition cost, and expected lifespan. Users can seamlessly enter the relevant information into these fields, ensuring that the system maintains a comprehensive record of each equipment asset.
To facilitate data entry, the page incorporates intuitive input mechanisms. Users can effortlessly enter the equipment's specifications by simply clicking on the corresponding fields and typing the desired information. The form is designed to be user-friendly, minimizing the potential for errors and ensuring a smooth data entry process.

</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/ffd9f931-a30d-4c87-815d-d2590ebdd9cc" width="300">
<br>
Patient Search  
On this page, the user can see a list of all registered patients in the system. They can search for a specific patient by using the search bar. After finding the patient they are looking for, they can click on the "View" button to see all the information about that patient.

</br>
<img src="https://github.com/zeinagarhy/zeinagarhy/assets/149964130/0b507e5a-c39f-43d5-8dfb-4de742808625" width="300">
<br>
</br>

## Contribution
- Silvia:
- Sama:
- Ann:
- Zeina:
- Rawan:
- Nourhan:

