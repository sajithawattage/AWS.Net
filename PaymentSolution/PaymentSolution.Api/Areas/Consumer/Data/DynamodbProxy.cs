using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentSolution.Api.Areas.Consumer.Data
{
    public class DynamodbProxy : IDynamodb
    {
        private readonly IAmazonDynamoDB _amazonDynamoDB;

        public DynamodbProxy(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
        }

        public async Task CreateDynamoDbTable()
        {
            try
            {
                await CreateTempTable();
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

        #region Private Method

        private async Task<string> CreateTempTable()
        {
            var request = new CreateTableRequest
            {
                TableName = "SampleTable",
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition
                    {
                        AttributeName = "Id",
                        AttributeType = "N"
                    },
                    new AttributeDefinition
                    {
                        AttributeName = "CreatedDateTime",
                        AttributeType = "N"
                    }
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement
                    {
                        AttributeName = "Id",
                        KeyType = KeyType.HASH
                    },
                    new KeySchemaElement
                    {
                        AttributeName ="CreatedDateTime",
                        KeyType = KeyType.RANGE
                    }
                },

                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 5,
                    WriteCapacityUnits = 5
                }
            };

            var response = await _amazonDynamoDB.CreateTableAsync(request);
            return response.TableDescription.TableStatus.Value;
        }

        #endregion
    }
}
