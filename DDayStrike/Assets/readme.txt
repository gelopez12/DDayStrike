*** In order to get the scene to properly go between one another, please build the scenes into the project. (It should not matter the order that the scenes are added)****


Bugs: There are quite a few places in each level that the player can fall out of the map, wedge through objects, fly into the air, climb up objects that should not be climbable, Dead allies can be moved around. 

There are also multiple instances of which the debug menu displays errors, however the game runs just as intended. 

Advanced Implementation:
	Animation: For the most part, the animations worked when they were called using bool variables. The animations play but some of them play slightly late or early. One of the biggest struggles was making the right transitions a the right time. We tried adding animations to the Enemies but they had a different joint module in which we were not able to implement "death" animations. 
	
	Pause Menu: Although it may not seem advance, we wanted to have the pause menu hide all the UI that was visible during game play, and have new UI pop up and be interactable; including a controls menu and a button to return back to the home screen. Unfortunely, every aspect of the canvas/UI was very spread out and disorganized,as well as misallocation of elements, to a point where we were only able to get one to work properly (level 3). Additionaly to the pause menu, due to the misallocation of elements, many elements of the canvas were unable to be anchored. 
