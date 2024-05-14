# CPTask
Starting the task
1] Created the necessary connection with CosmosDb (Cosmos Db emulator)
2] Created the Database and the container
3] Divided the task as mentioned in two parts Employer and Candidates
4] Candidate
   CandidateSubmissionControllerController:
   1./SubmitAnswer    
     - Takes a list of answers and sends a POST request
   2./GetSubmissionById/{id}
     - Returns a list of all answer submitted by candidate based on their id
   3./DeleteSubmission/{id}
     - Deletes all the answers given by the candidate based on the id

5] Employer
   QuestionsController
   1./CreateQuestion
     - Creates one question based on type and stores in Cosmos Db
   2./UpdateQuestion/{id}
     - Update the question with the given Id
   3./GetQuestionsByType/{type}
     - Get Question based on type (Eg: MCQ,Yes/No etc)
   4./GetQuestionsById/{id}
     - Gets a single question based on its Id

** Thinks I am thinking of adding to this program ***
Write Unit Test, A bit late for that nowww.
Create Endpoint to add multiple questions
Can add better error handling

Thanks for this. Cheers
