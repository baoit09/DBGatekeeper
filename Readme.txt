A.HTTP Services
	1. PatientController
		1.1 GetPatient: (DONE)
			+ POST
			+ {
				+ SQLString
				+ Checksum
				+ EthereumAddress
			  }
			+ Return: Hashtable Patient Info in JSON format

			+ Step 1: Get hashtable
			+ Step 2: Generate checksum
			+ step 3: Compare checksum
			+ Step 4: Return hashtable


	2. StudyController
		2.1 GetStudy: (DONE)
			+ POST
			+ {
				+ SQLString
				+ Checksum
				+ EthereumAddress
			  }
			+ Return: Hashtable Study Info in JSON format

			+ Step 1: Get hashtable
			+ Step 2: Generate checksum
			+ step 3: Compare checksum
			+ Step 4: Return hashtable


	3. ChecksumController (Done at 2:15)
		3.1 GenerateChecksum
			+ POST
			+ {
				+ SQLString
				+ EthereumAddress
			  }
			+ Return: Checksum in JSON format

			+ Step 1: Get hashtable base on SQLString
 			+ Step 2: Generate CHecksum base on hashtable
			+ Step 3: Return JSON {
					+ Checksum : "54678uhnkbgiuojy7yuio"
				}

B. BLL:  Business Services
	1. PatientService
		1.1 GetPatient(sqlString)
			+ Invoke PatientRepository
			+ Return 
			
	2. StudyService
	3. ChecksumService

C. DAL: using Microsoft's Data Access Application Block
	Data Access Services
	1. PatientRepository (DONE)
		1.1 Get Hashtable 
	2. StudyRepository (DONE)

================
