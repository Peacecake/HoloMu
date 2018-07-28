using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloMu.Networking
{
    public class RecommenderResult : RequestResult
    {
        public RecommenderResult(bool isSuccessful, string errorMessage) : base(isSuccessful, errorMessage)
        {
        }
    }

}
