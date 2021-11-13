# Stryker dotnet POC

The personal challenge here was to take someone else's C# github project and then apply Stryker a Mutation Testing tool to it. 
Key requirements were
1) To have a series of Unit Tests already built in
2) Relatively new Test Runner (no MSTest V1)
Repository selected was https://github.com/ichensky/BikeDistributor 

Note: I have made modifications so that the solution will build and the tests will pass. 
(A perfect candidate for incomplete unit test coverage).

# Approach
Load the solution, build and load the test explorer to see what is available. 
Stryker is already installed in the test project.

Within your command line navigate to
BikeDistributor.Test
And read the readme.md there.


NOTE: You can also install Stryker Globally. For notes on this, please refer to 
https://stryker-mutator.io/docs/stryker-net/getting-started#install-in-project