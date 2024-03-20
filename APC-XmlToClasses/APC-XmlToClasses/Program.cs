using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace APC_XmlToClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(() =>
            {
                Message message = new Message()
                {
                    Header = new MessageHeader()
                    {
                        MESSAGENAME = "APC_REQ_PARAMDATA",
                        TRANSACTIONID = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                        FACTORY = "FAB04",
                        AREA = "ETCH",
                        EQP_ID = "MC-DRYETCH01",
                        STAGE = "1",
                        RECIPE_ID = "RCP_20201129.04",
                        OPERATION_ID = "OP_001",
                        PRODUCT_ID = "PROD_TEST",
                        LOT_ID = "CYC00010"
                    },
                    Body = new MessageBody()
                    {
                        Chambers = new MessageBodyChamber[] {
                           new MessageBodyChamber(){
                               id="MC-LPCVD01-1",
                               RUN_MODE="Y",
                               STATUS="ACT",
                               ParameterList=new  MessageBodySubstrateParameter[]{
                                   new MessageBodySubstrateParameter(){  name="ETCH_TIME", step="3", value="100"},
                                   new MessageBodySubstrateParameter(){  name="ETCH_TIME", step="6", value="0"},
                                   new MessageBodySubstrateParameter(){  name="ETCH_TIME", step="9", value="0"},
                                   new MessageBodySubstrateParameter(){  name="ETCH_TIME", step="11", value="0"},
                               }
                           },
                             new MessageBodyChamber(){
                               id="MC-LPCVD01-2",
                               RUN_MODE="Y",
                               STATUS="ACT",
                               ParameterList=new  MessageBodySubstrateParameter[]{
                                   new MessageBodySubstrateParameter(){  name="ETCH_TIME", step="3", value="100"},
                                   new MessageBodySubstrateParameter(){  name="ETCH_TIME", step="6", value="00"},
                                   new MessageBodySubstrateParameter(){  name="ETCH_TIME", step="9", value="0"},
                                   new MessageBodySubstrateParameter(){  name="ETCH_TIME", step="11", value="0"},
                               }
                           },
                        }
                    },
                    Return = new MessageReturn()
                    {
                        RETURNCODE = "200",
                        RETURNMESSAGE = "OK"
                    }
                };

                var xmlStrings = XmlHelper.XmlSerialize(message, false);

                Console.WriteLine(xmlStrings);

                try
                {
                    Clipboard.SetText(xmlStrings);
                    Console.WriteLine("OK");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }));

            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();

            Console.WriteLine();
            Console.Read();
        }
    }
}
