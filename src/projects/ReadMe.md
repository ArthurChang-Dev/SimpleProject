## Backend project
This is the backend for SPA

### Run the app
Simply run the app without application, the service will be hosted at `http://localhost:3300`

### Issues
+ When using aws rds connection string
  - Since it's using 1433, so the server should be `Server=hostname,1433`
  - Remove config `Trusted_Connection=True` in connection string

### Deploy to Beanstalk
+ Use command to publish to folder `dotnet publish -o todo-app`
+ Zip everything in `todo-app` folder as `todo-app.zip`
+ Create beanstalk env and publish code
+ [Deploy .Net Core App to Beanstalk](https://docs.amazonaws.cn/en_us/elasticbeanstalk/latest/dg/dotnet-linux-core-tutorial.html)
+ [Create DB in beanstalk](https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/using-features.managing.db.html)
+ [Connect to AWS RDS from local](https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_ConnectToMicrosoftSQLServerInstance.html)
+ Access to AWS RDS - [Add inbound rule for vpc security group](https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Troubleshooting.html#CHAP_Troubleshooting.Connecting)
+ [Deploy React App to AWS S3](https://dev.to/karanpratapsingh/deploy-react-app-to-s3-cloudfront-1cao)

+ Todo - Comming Next: S3 connect to beanstalk
+ To read - https://www.linkedin.com/pulse/how-connect-your-backend-api-elastic-beanstalk-cloudfront-kamau/
