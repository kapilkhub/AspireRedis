var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("cache");

var apiservice = builder.AddProject<Projects.AspireRedis_ApiService>("apiservice")
	.WithReference(redis);

builder.AddProject<Projects.AspireRedis_Web>("webfrontend")
	.WithExternalHttpEndpoints()
	.WithReference(apiservice)
	.WithReference(redis);

builder.Build().Run();