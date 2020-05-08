using Cw6_APBD.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw6_APBD.Middleware
{
    public class LoggingMiddleware
    {

        private readonly RequestDelegate _next; //pole ktore jest 'delegatem' middleware

        public LoggingMiddleware(RequestDelegate next) //konstuktor
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IStudentDbService service) //context to nasz.. context czyli nasza 'sztafeta'
        {
            context.Request.EnableBuffering(); //dodajemy mozliwosc buforowania. Przydaje sie gdy chcemy odczytywac cialo zadania wiele razy.
             if(context.Request != null)
            {
                string path = context.Request.Path; //to nam da sciezke np w postaci api/students
                string method = context.Request.Method; //da nam metode, np GET, POST itp
                string queryString = context.Request.QueryString.ToString(); //i w koncu query, np 'Select...'
                string bodyString = "";

                //do otrzymania ciala zadania musimy zastosowac inna metode, poniewaz body przekazywane jest jako strumien
                using (var reader = new StreamReader(context.Request.Body,
                    Encoding.UTF8, true, 1024, true))
                {
                    bodyString = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0; //ustawiamy na 0, poniewaz to strumien i chcemy aby kolejne wywolania czytaly go od poczatku

                    //.. mozemy zapisac do pliku lub do bazy danych
                    string fPath = "Logs/LOGS.txt";

                    using (StreamWriter writer = File.AppendText(fPath))
                    {

                        await writer.WriteLineAsync("Path: " + path + ", Method: " + method +
                            ", Querry: " + queryString + ".");
                        await writer.WriteLineAsync("Body: " + reader);

                    }
                }

            }

            if(_next!=null) await _next(context); //czyli to bedzie przekazywanie dalej paleczki w sztafecie. Jesli by tego nie bylo, to bylby tzw. short circuit
        }

    }
}
