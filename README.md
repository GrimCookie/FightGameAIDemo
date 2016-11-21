# FightGameAIDemo
For my dissertation I researched nondeterministic Artificial intelligence methods that could be used in video 
games to provide a more unique playing experience. My goal was to make a tool that could show this technique 
in practice in a way that a first or second year student on the games development course could understand.

From my research I decided to use a Genetic programming algorithm. Over time the algorithm would improve upon 
a set of behaviour trees that control a conceptual AI fighter to show the possible use of such techniques that 
could be used in game AI.

The genetic operations used in the system were as follows: 
- **Grow** used for the generating of new trees.
- **bit flip mutation** chooses a node at random in the tree and altered it to another node within either the terminal or function node set (depending on the selected node).
- **sub-tree crossover** takes a section from the tree and swaps them between parents producing a new offspring.

These operations are performed throughout each generation of the program in order to herald better results at 
each subsequent stage. The system ends the process once a pre-determined number of generations have elapsed.

## Fluid behaviour tree builder
For this project I used The Fluent Behaviour-Tree API produced by Ashley Davis to handle the creation of the 
Behaviour tree data structures. This is an open source fluid behaviour tree builder which creates a behaviour 
tree for use in game AI using the C# language

Fluent Behaviour-Tree by Davis:
http://www.what-could-possibly-go-wrong.com/fluent-behavior-trees-for-ai-and-game-logic/
