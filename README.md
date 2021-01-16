# Pyramid

## Rules
You will be given a triangle input (which is a directed graph) and you need to find the path that provides the maximum possible sum of the numbers per the given rules below:
1. You will start from the top and move downwards to the last possible node.
1. You must proceed by changing between even and odd numbers subsequently. Suppose that you are on an even number, the next number you choose must be odd,
   or if you are on an odd number the next number must be even. In other words, the final path would be Odd -> even -> odd -> even …
1. You can only move down on the same column and 1 on the right. I.e. if your node is on column 2, the next node cannot be on column 0..1, but 2 and 3 
1. You must reach to the bottom of the pyramid.
1. Assume that there is at least one valid path to the bottom.
1. If there are multiple paths, which result in the same maximum amount, you can choose any of them.


## Running

### Requirements
- dotnet 5

### Execution steps
- dotnet build
- dotnet run