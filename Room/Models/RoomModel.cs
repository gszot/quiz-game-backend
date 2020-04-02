using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Tasak.Api.Room.Hubs;

namespace Tasak.Api.Room.Models
{
    public class RoomModel
    {
        //player:
        //
        //setup_conn:          c:pin,nick s:verify
        //start_question:      s:Q&A
        //                     c:answer(na request)
        //end_question:        s:verify
        //end_quiz:            s:scores
        //-------------------------------------------------
        //teacher:
        //
        //start_quiz
        //stop_question
        //next_question
        public string RoomId { get; set; }
        public string TeacherConnectionId { get; set; }
        public IHubContext<RoomHub> HubContext { get; set; }
        public ICollection<RoomPlayer> Players { get; set; }
        public bool CanAnswer { get; set; }
        public bool CanJoin { get; set; }
        public int Question_Number { get; set; }
        public int Questions_Amount { get; set; } = 5;
        public IList<Question> Questions { get; set; }
        public IList<string> RightAnswers { get; set; }
        public void StartRoom()
        {
            Debug.WriteLine("startroom");
            CanJoin = true;
            CanAnswer = false;
        }
        public void CloseRoom()
        {
            Debug.WriteLine("closeroom");
            CanJoin = false;
        }
        public void LoadQuestions()
        { }
        public async Task StartQuiz()
        {
            Debug.WriteLine("startquiz");
            CloseRoom();
            LoadQuestions();
            Question_Number = 0;
            await StartQuestion();
        }
        public async Task StartQuestion()
        {
            Debug.WriteLine("startquestion");
            CanAnswer = true;
            /*foreach(RoomPlayer player in Players)
            {
                player.Answers.Add(null);
            }*/
            //HubContext.Clients.Group(RoomId).SendAsync("start_question", Questions[Question_Number].ToString());
            await HubContext.Clients.Group(RoomId).SendAsync("start_question", "pytaniezbazydanych");
            Debug.WriteLine("postartquestion");
        }
        public async Task StopQuestion()
        {
            Debug.WriteLine("stopquestion");
            CanAnswer = false;
            await EvaluateAnswers();
        }
        public async Task EvaluateAnswers()
        {
            Debug.WriteLine("evaluateanswers");
            await HubContext.Clients.Client(TeacherConnectionId).SendAsync("end_question", true);
            /*foreach (RoomPlayer player in Players)
            {
                if( player.Answers[Question_Number] == RightAnswers[Question_Number] )
                {
                    HubContext.Clients.Client(player.ConnectionId).SendAsync("end_question", true);
                }
                else
                {
                    HubContext.Clients.Client(player.ConnectionId).SendAsync("end_question", false);
                }
            }*/
        }
        public async Task NextQuestion()
        {
            Debug.WriteLine("nextquesiton");
            Question_Number += 1;
            if (Question_Number >= Questions_Amount)
            {
                await EndQuiz();
            }
            else
            {
                CanAnswer = true;
                await StartQuestion();
            }
        }
        public async Task EndQuiz()
        {
            Debug.WriteLine("endquiz");
            var scores = new Scores();
            /*foreach(RoomPlayer player in Players)
            {
                var playerScore = new Player { Nick = player.Nick, Score = player.Score };
                scores.PlayerScores.Add(playerScore);
            }*/
            await HubContext.Clients.Group(RoomId).SendAsync("end_quiz", scores);
        }
    }
}
