# The-Game-of-Nim-C#
A Program to play the game of Nim written in C#

The game of Nim is a mathematical game of strategy where two players take turns removing items from a set of heaps, each turn a player must remove form a minimum of one to any number of items as long it’s from a single heap, and the goal of the game is to take the last item/s from the last non-empty heap and the player that does so is declared winner, there are other versions of Nim with different goals or rules, an example of that is the misère game in which the player to take the last item loses, but in this project we will cover the main version only.

The game is mathematically solved for any number of heaps using the XOR logical operation '⊕', which only returns 1 if the number of 1s in each digit is odd.
by using it on the binary equivalent of the number of items in each heap you get a value known as the NimSum, as long as the NimSum isn't 0 the player to play first wins with correct play, otherwise the second player has a winning position.

The winnig strategy is to find a heap that fulfilss the following equation: (number of items in heap ⊕ NimSum of all heaps < number of items in heap) and the reducing that heap to the value of (number of items in heap ⊕ NimSum of all heaps), this way you will ensure that the other player will always start his turn with a NimSum of 0.
Example: let's say we have 3 heaps with 2, 3, 4 items respectively, the NimSum will be as follows

2 = 010

3 = 011

4 = 100

NimSum = 101 = 5

now to find the correct heap to play in: 5 ⊕ 2 = 7 | 5 ⊕ 3 = 6 | 5 ⊕ 4 = 1
which mean the winning move is to reduce the third heap from 4 to 1, let's check the NimSum again after that 

2 = 010

3 = 011

1 = 001

NimSum = 000 = 0

which means any move the player to play next makes will change the NimSum form 0 to another value, so they are loosing, and then the game go on like this until it ends.


