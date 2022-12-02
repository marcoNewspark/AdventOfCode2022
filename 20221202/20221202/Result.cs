using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221202
{
    internal class Result
    {
        enum MatchResult
        {
            Lose,
            Draw, 
            Win
        };

        enum Shape
        {
            Rock,
            Paper,
            Scissors
        };

        record MatchMove: IDisposable
        {
            Shape hisMove;
            Shape myMove;
            private bool disposedValue;

            public MatchMove(Shape HisMove, Shape MyMove)
            {
                (hisMove, myMove) = (HisMove, MyMove);
            }
            public string Dump()
            {
                string hm;
                string mm;
                hm = hisMove switch
                {
                    Shape.Rock => "Rock", 
                    Shape.Paper => "Paper",
                    Shape.Scissors => "Scissors" 
                };

                mm = myMove switch
                {
                    Shape.Rock => "Rock",
                    Shape.Paper => "Paper",
                    Shape.Scissors => "Scissors"
                };

               return ($"{hm} {mm}");
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects)
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                    // TODO: set large fields to null
                    disposedValue = true;
                }
            }

            // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
            // ~MatchMove()
            // {
            //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            //     Dispose(disposing: false);
            // }

            public void Dispose()
            {
                // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }


        private Dictionary<MatchResult, int> _matchResultScore = new Dictionary<MatchResult, int>();
        private Dictionary<string, Shape> _myShapes = new Dictionary<string, Shape>();
        private Dictionary<MatchMove, int> _shapeResults = new Dictionary<MatchMove, int>();
        private Dictionary<Shape, int> _shapeScores = new Dictionary<Shape, int>();
        
        /* 
         * X=I should lose
         * Y=Ishould draw
         * Z=I should win
         * 
         */

        public Result()
        {
            /*
            *  A for Rock, B for Paper, and C for Scissors. The second column--" Suddenly, the Elf is called away to help with someone's tent.

               The second column, you reason, must be what you should play in response: X for Rock, Y for Paper, and Z for Scissors. Winning every time would be

               A beats Z
               B beats X
               C beats Y

               A > Z
               B > X
               C > Y

               Rock: 1
               Paper: 2
               Scissors: 3
           score of the shape: 1 for Rock, 2 for Paper, and 3 for Scissors
               score for the outcome of the round :0 if you lost, 3 if the round was a draw, and 6 if you won.

               Shapes:

               outcomes:
                   Lose    0
                   Draw    3
                   Win     6
           */
            // set up result scores
            _matchResultScore.Add(MatchResult.Lose, 0);
            _matchResultScore.Add(MatchResult.Draw, 3);
            _matchResultScore.Add(MatchResult.Win, 6);

            // set up shape mapper for him
            _myShapes.Add("A", Shape.Rock);
            _myShapes.Add("B", Shape.Paper);
            _myShapes.Add("C", Shape.Scissors);

            // set up shape mapper for me
            _myShapes.Add("X", Shape.Rock);
            _myShapes.Add("Y", Shape.Paper);
            _myShapes.Add("Z", Shape.Scissors);

            _shapeResults.Add(new(Shape.Rock, Shape.Rock), 3);
            _shapeResults.Add(new(Shape.Rock, Shape.Paper), 6);
            _shapeResults.Add(new(Shape.Rock, Shape.Scissors), 0);

            _shapeResults.Add(new(Shape.Paper, Shape.Paper), 3);
            _shapeResults.Add(new(Shape.Paper, Shape.Scissors), 6);
            _shapeResults.Add(new(Shape.Paper, Shape.Rock), 0);

            _shapeResults.Add(new(Shape.Scissors, Shape.Scissors), 3);
            _shapeResults.Add(new(Shape.Scissors, Shape.Rock), 6);
            _shapeResults.Add(new(Shape.Scissors, Shape.Paper), 0);

            _shapeScores.Add(Shape.Scissors, 3);
            _shapeScores.Add(Shape.Rock, 1);
            _shapeScores.Add(Shape.Paper, 2);


        }

        /* 
         * X=I should lose
         * Y=Ishould draw
         * Z=I should win
         * 
         */
        public int CalculateResult2(Move move)
        {
            int result = 0;

            Dictionary<string, MatchResult> matchResult2 = new Dictionary<string, MatchResult>();
            matchResult2.Add("X", MatchResult.Lose);
            matchResult2.Add("Y", MatchResult.Draw);
            matchResult2.Add("Z", MatchResult.Win);

            Shape hisShape = _myShapes[move.HisMove];
            Shape myShape = Shape.Paper ;

            // get match result, then determine what I should play.
            // calculate points on that combination
            switch(matchResult2[move.MyMove])
            {
                case MatchResult.Lose:
                    {
                        switch(_myShapes[move.HisMove])
                        {
                            case Shape.Rock:
                                {
                                    myShape = Shape.Scissors;
                                    break;

                                }
                            case Shape.Paper:
                                {
                                    myShape = Shape.Rock;
                                    break;
                                }
                            case Shape.Scissors:
                                {
                                    myShape=Shape.Paper;
                                    break;

                                }
                        }
                        break;
                    }

                case MatchResult.Draw:
                    {
                        myShape = hisShape;
                        
                        break;
                    }
                case MatchResult.Win:
                    {
                        switch (_myShapes[move.HisMove])
                        {
                            case Shape.Rock:
                                {
                                    myShape = Shape.Paper;
                                    break;

                                }
                            case Shape.Paper:
                                {
                                    myShape = Shape.Scissors;
                                    break;
                                }
                            case Shape.Scissors:
                                {
                                    myShape = Shape.Rock;
                                    break;

                                }
                        }
                        break;
                    }
            }

            using (MatchMove matchMove = new(hisShape, myShape))
            {

                result = _shapeScores[myShape] + _shapeResults[matchMove];
                Console.WriteLine($"{matchMove.Dump()}");
                Console.WriteLine($"SS:{_shapeScores[myShape]} SR:{_shapeResults[matchMove]} Total:{result}");
            }
            return result;
        }
        public int CalculateResult(Move move)
        {
           
            int result = 0;
            
            using (MatchMove matchMove = new(_myShapes[move.HisMove], _myShapes[move.MyMove]))
            {
                
                result = _shapeScores[_myShapes[move.MyMove]]+ _shapeResults[matchMove];
                Console.WriteLine($"{matchMove.Dump()}");
                Console.WriteLine($"SS:{_shapeScores[_myShapes[move.MyMove]]} SR:{_shapeResults[matchMove]} Total:{result}");
            }

            return result;
        }
    }
}
