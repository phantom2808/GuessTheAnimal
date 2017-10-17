GuessTheAnimal
--------------
	A console application that can be excecuted by running GuessTheAnimal.exe from the command-line.

	Animals.xml used to persist data and read via XDocument.

	LINQ queries used to search for the Animal based on the players answers.

	The game can be replayed without restarting the application.

	After 3 questions are asked relating to the Animal the answer will be returned.

Assumptions
-----------
	Duplicate animals can be entered - however if an animal is added that is duplicate, the first one found will be returned.

Test Data
---------
	As per Problem Statement example ie:

	Animals.xml has been seeded with:

		<Animals>
		  <Animal>
			<name>Elephant</name>
			<sound>trumpets</sound>
			<feature>trunk</feature>
			<colour>grey</colour>
		  </Animal>
		  <Animal>
			<name>Lion</name>
			<sound>roars</sound>
			<feature>mane</feature>
			<colour>yellow</colour>
		  </Animal>
		</Animals>

	when the game guesses the animal, the output will be of the format:

		<Animal>; has a <feature>, <sound> and is <colour>


	Otherwise the player will be informed that the game can't guess the Animal.

Tests
-----
	-	Entering answers in any case (upper, lower and mixed).
	-	Finding one of the seed Animals.
	-	Finding one of the Added animals via the 'add' function.
	-	Providing answers that do not result in an Animal being guessed.
	-	Restarting game without restarting the application.







	

