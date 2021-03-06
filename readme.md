S3Emulator
==============
S3Emulator is a lightweight server which mimics the services of Amazon S3. It can be useful for development and testing porpuses. 
By reducing network traffic, it saves both the time and the money.

Supported Operations
--------------------
- [GET Service][5]  
- [PUT Bucket][6]  
- [DELETE Bucket][7]  
- [HEAD Bucket][8]  
- [GET Bucket(List Objects)][9]  
- [PUT Object][10]  
- [GET Object][11]  
- [DELETE Object][12]  

How to use it ?
---------------
Download the application from [here][1]. Open a command promt window and just enter : "S3Emulator"  
When started with default options, all the requests made to "s3.amazonaws.com" will be redirected to S3Emulator.  
You can see the full list of options by entering : "S3Emulator -help"  

Options
-------
- Service  
  Address of s3 service that will be emulated.  
  Default: s3.amazonaws.com  
  
- Proxy  
  Proxy is used for supporting secure connections and [subdomain style bucket names][2].  
  If you disable proxy, you need to use http protocol and request-uri syle bucket names.  
  [FiddlerCore][3] is used for proxy support.  
  Default: true  
  
- ProxyPort  
  The port to use for the proxy.  
  Default: 8877  
  
- HostPort  
  The port to use for the S3Emulator's http listener.  
  Default: 8878  
  
- Directory  
  The directory for the storage operations.  
  [RavenDB][4] is used for persistance.  
  Default: ~\Data  
  
- InMemory  
  If set to true, all storage operations will be in memory.  
  Default: false  
  
- MaxBPS  
  Set maximum bytes per second. Can be used for bandwidth throttling.  
  Default: infinite  
  
[0]: http://github.com/yadazula/S3Emulator "S3Emulator on Github"
[1]: http://github.com/yadazula/S3Emulator/downloads "download"
[2]: http://docs.amazonwebservices.com/AmazonS3/latest/dev/VirtualHosting.html#VirtualHostingSpecifyBucket
[3]: http://www.fiddler2.com/Fiddler/Core/
[4]: http://ravendb.net
[5]: http://docs.amazonwebservices.com/AmazonS3/latest/API/RESTServiceGET.html
[6]: http://docs.amazonwebservices.com/AmazonS3/latest/API/RESTBucketPUT.html
[7]: http://docs.amazonwebservices.com/AmazonS3/latest/API/RESTBucketDELETE.html
[8]: http://docs.amazonwebservices.com/AmazonS3/latest/API/RESTBucketHEAD.html
[9]: http://docs.amazonwebservices.com/AmazonS3/latest/API/RESTBucketGET.html
[10]: http://docs.amazonwebservices.com/AmazonS3/latest/API/RESTObjectPUT.html
[11]: http://docs.amazonwebservices.com/AmazonS3/latest/API/RESTObjectGET.html
[12]: http://docs.amazonwebservices.com/AmazonS3/latest/API/RESTObjectDELETE.html