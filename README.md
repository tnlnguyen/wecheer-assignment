## ❯ Getting Started
This project has been developed by ASP.NET Core 6 and Angular.
I have designed this architecture for backend and frontend development.

Backend server was deployed to AWS Lambda function and frontend was deployed to AWS S3.

Here is the architecture of this assignment which includes AWS Kinesis Stream:
<img width="1135" alt="Screenshot 2023-07-01 at 20 40 39" src="https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/0c316dd8-ff0f-448b-8f17-8aae1f759a68">


AWS Configuration Images:

	+ Total function created:
 <img width="1684" alt="Screenshot 2023-07-01 at 20 45 08" src="https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/5ffd5a66-1f99-436d-8ebf-d6ed718374f8">

	+ ImageStreaming (ASP.NET Core 6):
<img width="1717" alt="Screenshot 2023-07-01 at 20 45 46" src="https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/14f15af2-c9b5-4f1f-9a74-84d75d49713d">

	+ Kinesis Consumer: 
<img width="1667" alt="Screenshot 2023-07-01 at 20 46 51" src="https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/3a022f31-6562-4175-9949-946d87a02b92">

	+ API Gateway Created:
<img width="1543" alt="Screenshot 2023-07-01 at 20 47 54" src="https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/7942d312-ab6f-4f3c-b3ac-798639a8f4c7">

	+ S3 For Angular Deployment:
<img width="1475" alt="Screenshot 2023-07-01 at 20 48 30" src="https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/1e59db2c-bc21-4365-8fad-a631b4ad6e38">
	

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
![Screenshot 2023-07-01 at 20 52 25](https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/5d465bba-d2e8-49b2-aec6-4def7b72eadb)


Then check the configuration list in AWS CLI with

```bash
aws configure list
```
![Screenshot 2023-07-01 at 20 52 40](https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/8d05b4e8-d91c-4b4e-947e-bc68d6b8e130)


Finally, you can trigger the Kinesis Stream via the following command (replace data with url and desc you want)

```bash
aws kinesis put-record --stream-name wecheer-events --partition-key 1111 --data '{"url": "https://upload.wikimedia.org/wikipedia/commons/b/b6/Image_created_with_a_mobile_phone.png", "desc": "test kinesis number 2"}' --cli-binary-format raw-in-base64-out
```
![image](https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/144f6d4b-ae26-40e7-a310-b2048a5d8a36)


### How to send a new event

You can send a event to ASP.NET Core 6 Lambda via Swagger Documentation. Please use the suggested payload format by Swagger Documentation
<img width="1797" alt="image" src="https://github.com/tnlnguyen/wecheer-assignment/assets/55527299/5e178d89-57c1-48e1-b0c6-2f57c987fcc3">

Developed By Nhan Le
