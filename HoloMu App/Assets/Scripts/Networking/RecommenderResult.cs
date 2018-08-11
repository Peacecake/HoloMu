using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloMu.Networking
{
    public class RecommenderResult : RequestResult
    {
        public string Recommendation { get; private set; }

        public RecommenderResult(bool isSuccessful, string errorMessage, string resultText) : base(isSuccessful, errorMessage)
        {
            this.Recommendation = resultText;
        }
    }

}
