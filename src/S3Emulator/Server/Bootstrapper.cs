﻿using System;
using System.Collections.Generic;
using Nancy;
using Raven.Client;
using Raven.Client.Embedded;
using S3Emulator.Config;
using S3Emulator.Model;
using S3Emulator.Server.Responses;
using S3Emulator.Server.Responses.Serializers;
using S3Emulator.Storage;
using S3Emulator.Storage.Indexes;

namespace S3Emulator.Server
{
  public class Bootstrapper : DefaultNancyBootstrapper, IDisposable
  {
    private readonly S3Configuration s3Configuration;
    private readonly IDocumentStore documentStore;

    public Bootstrapper(S3Configuration s3Configuration)
    {
      this.s3Configuration = s3Configuration;
      documentStore = new EmbeddableDocumentStore
      {
        DataDirectory = s3Configuration.DataDirectory,
        RunInMemory = s3Configuration.RunInMemory
      };

      documentStore.Initialize();
      Raven.Client.Indexes.IndexCreation.CreateIndexes(typeof(S3Object_Search).Assembly, documentStore);
    }

    protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
    {
      container.Register(documentStore);
      container.Register(s3Configuration);
      container.Register<IS3Storage, RavenDBStorage>().AsSingleton();
      
      var s3Responder = BuildResponder();
      container.Register(s3Responder);
    }

    public static IS3Responder BuildResponder()
    {
      var s3Serializers = new Dictionary<Type, IS3Serializer>
      {
        {typeof (List<Bucket>), new BucketListSerializer()},
        {typeof (S3ObjectSearchResponse), new S3ObjectSearchSerializer()},
        {typeof (BucketNotFound), new BucketNotFoundSerializer()},
        {typeof (ACLRequest), new ACLSerializer()},
        {typeof (DeleteRequest), new DeleteResultSerializer()}
      };

      IS3Responder s3Responder = new S3XmlResponder(s3Serializers);
      return s3Responder;
    }

    public void Dispose()
    {
      documentStore.Dispose();
    }
  }
}