# Mastermind Kata #

**A simple C# Console App version of Mastermind.**

The randomly generated answer should be four (4) digits in length, with each digit between the numbers 1 and 6.  

After the player enters a combination:
* a minus (-) sign should be printed for every digit that is correct but in the wrong position
* a plus (+) sign should be printed for every digit that is both correct and in the correct position
* Nothing should be printed for incorrect digits.  

The player has ten (10) attempts to guess the number correctly before receiving a message that they have lost.

## Assumptions
Initial game start simple and not allow repeating numbers
The answer will always bring back 4 characters, notable wrong number will being back an empty space.
Any input with invalid input will count as an attempt
