using System;
using System.Collections;
using System.Collections.Generic;

namespace MarsRoverProblems
{
    public class MarsRover
    {

        public List<string> MarsRoverMove(Dictionary<ArrayList, List<string>> keyValues)
        {
            List<string> result = new List<string>();

            foreach (var entry in keyValues)
            {
                ArrayList initialValue = entry.Key;
                List<string> rotateList = entry.Value;

                for (var i = 0; i < rotateList.Count; i++)
                {
                    var direction = rotateList[i];           // hareket etmesi gereken yön bilgsidir.

                    switch (direction)
                    {
                        case "L":
                            LeftRightRotate(direction, initialValue);
                            break;
                        case "R":
                            LeftRightRotate(direction, initialValue);
                            break;
                        case "M":
                            RoboticRoverMoved(direction, initialValue);
                            break;
                    }
                }

                result.Add(String.Join(" ", initialValue.ToArray()));
            }


            return result;

        }


        /// <summary>
        /// L ve R göre yeni konumu bulan methodtur.
        /// L yapacak ise 90 derecelik açı ile sola hareket edecektir. 
        /// R yapacak ise 90 derecelik açı ile sağa hareket edecektir.
        /// </summary>
        /// <param name="direction"> Yönlemek istedigi L veya R bilgisidir.</param>
        /// <param name="oldRotate">  O anki konumudur. </param>
        public ArrayList LeftRightRotate(string direction, ArrayList initialValue)
        {
            var oldRotate = initialValue[2].ToString(); // o anki yön bilgisi dir.

            List<string> cardinalDirection = new List<string> { "N", "E", "S", "W" };
            var yon = cardinalDirection.FindIndex(x => x == oldRotate);

            #region L ve R göre yeni yön bulmaktadır.
            if (direction == "L")
            {
                yon = yon - 1;
                if (yon < 0)
                {
                    yon = cardinalDirection.Count - 1;
                }
            }
            else if (direction == "R")
            {
                yon = yon + 1;
                if (yon >= cardinalDirection.Count)
                {
                    yon = 0;
                }
            }

            initialValue[2] = cardinalDirection[yon];
            #endregion

            return initialValue;
        }



        /// <summary>
        /// O anki yön bilgisine göre yeni konumu bulan method tur.
        /// O anki bulundugu yöne göre hareket edecektir.
        /// Eger W yönünde ise 1 adım ileri gitmek için x kordinat degerinden 1 çıkarılır.
        /// Eger E yönünde ise 1 adım ileri gitmek için x kordinat degerine 1 ekleme yapılır.
        /// Eger S yönünde ise 1 adım ileri gitmek için y kordinat degerinden 1 çıkarılır.
        /// Eger N yönünde ise 1 adım ileri gitmek için y kordinat degerine 1 ekleme yapılır.
        /// </summary>
        /// <param name="direction"> O anki yön bilgisidir. </param>
        /// <param name="initialValue">  O anki konumudur. </param>
        public ArrayList RoboticRoverMoved(string direction, ArrayList initialValue)
        {
            var nowRotate = initialValue[2].ToString();
            if (nowRotate == "W")
            {
                initialValue[0] = Convert.ToInt32(initialValue[0]) - 1;
            }
            else if (nowRotate == "E")
            {
                initialValue[0] = Convert.ToInt32(initialValue[0]) + 1;
            }
            else if (nowRotate == "N")
            {
                initialValue[1] = Convert.ToInt32(initialValue[1]) + 1;
            }
            else if (nowRotate == "S")
            {
                initialValue[1] = Convert.ToInt32(initialValue[1]) - 1;
            }

            return initialValue;
        }

    }
}
