using System;
using TechTalk.SpecFlow;

namespace RayCasterEngine.Specs
{
    [Binding]
    public class TuplesVectorsAndPointsSteps
    {
        [Given(@"a(.*) ← tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenATuple(int p0, int p1, int p2, int p3, int p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"p(.*) ← point\((.*), (.*), (.*)\)")]
        public void GivenPPoint(int p0, int p1, int p2, int p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"v(.*) ← vector\((.*), (.*), (.*)\)")]
        public void GivenVVector(int p0, int p1, int p2, int p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"zero ← vector\((.*), (.*), (.*)\)")]
        public void GivenZeroVector(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a ← vector\((.*), (.*), (.*)\)")]
        public void GivenAVector(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"b ← vector\((.*), (.*), (.*)\)")]
        public void GivenBVector(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"c ← color\((.*), (.*), (.*)\)")]
        public void GivenCColor(Decimal p0, Decimal p1, Decimal p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"c(.*) ← color\((.*), (.*), (.*)\)")]
        public void GivenCColor(int p0, Decimal p1, Decimal p2, Decimal p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"c(.*) ← color\((.*), (.*), (.*)\)")]
        public void GivenCColor(int p0, int p1, Decimal p2, Decimal p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"c(.*) ← color\((.*), (.*), (.*)\)")]
        public void GivenCColor(int p0, Decimal p1, int p2, Decimal p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"n ← vector\((.*), (.*), (.*)\)")]
        public void GivenNVector(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"n ← vector\(√(.*), √(.*), (.*)\)")]
        public void GivenNVector(string p0, string p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"norm ← normalize\(v\)")]
        public void WhenNormNormalizeV()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"r ← reflect\(v, n\)")]
        public void WhenRReflectVN()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a(.*) \+ a(.*) = tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenAATuple(int p0, int p1, int p2, int p3, int p4, int p5)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"p(.*) - p(.*) = vector\((.*), (.*), (.*)\)")]
        public void ThenP_PVector(int p0, int p1, int p2, int p3, int p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"p - v = point\((.*), (.*), (.*)\)")]
        public void ThenP_VPoint(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"v(.*) - v(.*) = vector\((.*), (.*), (.*)\)")]
        public void ThenV_VVector(int p0, int p1, int p2, int p3, int p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"zero - v = vector\((.*), (.*), (.*)\)")]
        public void ThenZero_VVector(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"-a = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_ATuple(int p0, int p1, int p2, int p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a \* (.*) = tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenATuple(Decimal p0, Decimal p1, int p2, Decimal p3, int p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a / (.*) = tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenATuple(int p0, Decimal p1, int p2, Decimal p3, int p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"magnitude\(v\) = (.*)")]
        public void ThenMagnitudeV(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"magnitude\(v\) = √(.*)")]
        public void ThenMagnitudeV(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"normalize\(v\) = vector\((.*), (.*), (.*)\)")]
        public void ThenNormalizeVVector(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"normalize\(v\) = approximately vector\((.*), (.*), (.*)\)")]
        public void ThenNormalizeVApproximatelyVector(Decimal p0, Decimal p1, Decimal p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"magnitude\(norm\) = (.*)")]
        public void ThenMagnitudeNorm(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"dot\(a, b\) = (.*)")]
        public void ThenDotAB(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"cross\(a, b\) = vector\((.*), (.*), (.*)\)")]
        public void ThenCrossABVector(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"cross\(b, a\) = vector\((.*), (.*), (.*)\)")]
        public void ThenCrossBAVector(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"c\.red = (.*)")]
        public void ThenC_Red(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"c\.green = (.*)")]
        public void ThenC_Green(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"c\.blue = (.*)")]
        public void ThenC_Blue(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"c(.*) \+ c(.*) = color\((.*), (.*), (.*)\)")]
        public void ThenCCColor(int p0, int p1, Decimal p2, Decimal p3, Decimal p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"c(.*) - c(.*) = color\((.*), (.*), (.*)\)")]
        public void ThenC_CColor(int p0, int p1, Decimal p2, Decimal p3, Decimal p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"c \* (.*) = color\((.*), (.*), (.*)\)")]
        public void ThenCColor(int p0, Decimal p1, Decimal p2, Decimal p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"c(.*) \* c(.*) = color\((.*), (.*), (.*)\)")]
        public void ThenCCColor(int p0, int p1, Decimal p2, Decimal p3, Decimal p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"r = vector\((.*), (.*), (.*)\)")]
        public void ThenRVector(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
