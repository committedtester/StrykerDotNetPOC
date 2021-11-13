# Stryker Known Limitation

Stryker has a limitation in that it cannot have multiple reference projects being mutated at the same time
(You can have multiple test projects)

To get around this, there is this repository here
https://github.com/rajbos/Stryker.MultipleProjectRunner

For the time constraint purposes of this POC I am removing the project from the configuration file and running it twice


# Execution

Execute the following commands within the BikeDistributor.Test directory

dotnet stryker --project BikeDistributor.Domain.csproj
dotnet stryker --project BikeDistributor.Infrastructure.csproj

Reports will be written to the StrykerOutput directory