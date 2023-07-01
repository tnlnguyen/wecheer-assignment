## ❯ Getting Started
This project has been developed by ASP.NET Core 6 and Angular.
I have designed this architecture for backend and frontend development.

Backend server was deployed to AWS Lambda function and frontend was deployed to AWS S3.

Here is the architecture of this assignment which includes AWS Kinesis Stream:


AWS Configuration Images:

	+ Total function created:

	+ ImageStreaming (ASP.NET Core 6):

	+ Kinesis Consumer: 

	+ API Gateway Created:

	+ S3 For Angular Deployment:
	

**NOTE**:
Swagger: https://zlx7x0vgsk.execute-api.us-east-1.amazonaws.com/swagger/index.html

API Gateway: https://zlx7x0vgsk.execute-api.us-east-1.amazonaws.com

Angular app: http://wecheer-app.s3-website-us-east-1.amazonaws.com/



Please read the documentation below for more information to run the project.

### How to trigger Kinesis Stream

Since I don't develop a producer service, so we just trigger the Kinesis Stream via AWS CLI for now.

Please configure AWS CLI with the credential which I attached in the mail (Access Key ID, Secret Access Key)

Run these commands to configure the AWS CLI:

```bash
aws configure
```

Then check the configuration list in AWS CLI with

```bash
aws configure list
```

Finally, you can trigger the Kinesis Stream via the following command (replace data with url and desc you want)

```bash
aws kinesis put-record --stream-name wecheer-events --partition-key 1111 --data '{"url": "https://upload.wikimedia.org/wikipedia/commons/b/b6/Image_created_with_a_mobile_phone.png", "desc": "test kinesis number 2"}' --cli-binary-format raw-in-base64-out
```

### How to send a new event

You can send a event to ASP.NET Core 6 Lambda via Swagger Documentation. Please use the suggested payload format by Swagger Documentation
