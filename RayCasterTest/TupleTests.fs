module TupleTests

open System
open Xunit
open RayCasterEngine

[<Fact>]
let ``A tuple with w=1 is a point`` () =
    let x, y, z, w = (4.3, -4.2, 3.1, 1.0)
    let testTuple = Tuple3d (x, y, z, w)
  
    (x = testTuple.X && y = testTuple.Y && z = testTuple.Z && w = testTuple.W)
    |> Assert.True

[<Fact>]
let ``A tuple with w=0 is a vector`` () =
    let x, y, z, w = (4.3, -4.2, 3.1, 0.0)
    let testTuple = Tuple3d (x, y, z, w)
  
    (x = testTuple.X && y = testTuple.Y && z = testTuple.Z && w = testTuple.W)
    |> Assert.True

[<Fact>]
let ``Point() creates tuples with w=1`` () =
    let x, y, z = (4.0, -4.0, 3.0)
    let point = Tuple3d.Point (x, y, z)
    let expected = Tuple (Tuple3d(x, y, z, 1.0))

    point = expected
    |> Assert.True

[<Fact>]
let ``Vector() creates tuples with w=0`` () =
    let x, y, z = (4.0, -4.0, 3.0)
    let vector = Tuple3d.Vector (x, y, z)
    let expected = Tuple (Tuple3d(x, y, z, 0.0))

    vector = expected
    |> Assert.True

[<Fact>]
let ``Adding two tuples`` () =
    let tuple1 = Tuple (Tuple3d (3.0, -2.0, 5.0, 1.0))
    let tuple2 = Tuple (Tuple3d (-2.0, 3.0, 1.0, 0.0))
    let expected = Tuple (Tuple3d (1.0, 1.0, 6.0, 1.0))

    tuple1 + tuple2 = expected
    |> Assert.True

[<Fact>]
let ``Subtracting two points`` () =
    let p1 = Tuple3d.Point (3.0, 2.0, 1.0)
    let p2 = Tuple3d.Point (5.0, 6.0, 7.0)

    p1 - p2 = Tuple3d.Vector (-2.0, -4.0, -6.0)
    |> Assert.True

[<Fact>]
let ``Subtracting a vector from a point`` () =
    let p = Tuple3d.Point (3.0, 2.0, 1.0)
    let v = Tuple3d.Vector (5.0, 6.0, 7.0)

    p - v = Tuple3d.Point (-2.0, -4.0, -6.0)
    |> Assert.True

[<Fact>]
let ``Subtracting two vectors`` () =
    let v1 = Tuple3d.Vector (3.0, 2.0, 1.0)
    let v2 = Tuple3d.Vector (5.0, 6.0, 7.0)

    v1 - v2 = Tuple3d.Vector (-2.0, -4.0, -6.0)
    |> Assert.True

[<Fact>]
let ``Negating a tuple`` () =
    let t = Tuple (Tuple3d (1.0, -2.0, 3.0, -4.0))
    let expected = Tuple (Tuple3d (-1.0, 2.0, -3.0, 4.0))

    -t = expected
    |> Assert.True

[<Fact>]
let ``Multiplying a tuple by a scalar`` () =
    let a = Tuple (Tuple3d (1.0, -2.0, 3.0, -4.0))

    a * 3.5 = Tuple (Tuple3d (3.5, -7.0, 10.5, -14.0))
    |> Assert.True

[<Fact>]
let ``Multiplying a tuple by a fraction`` () =
    let a = Tuple (Tuple3d (1.0, -2.0, 3.0, -4.0))
    
    a * 0.5 = Tuple (Tuple3d (0.5, -1.0, 1.5, -2.0))
    |> Assert.True

[<Fact>]
let ``Dividing a tuple by a scalar`` () =
    let a = Tuple (Tuple3d (1.0, -2.0, 3.0, -4.0))

    a / 2.0 = Tuple (Tuple3d (0.5, -1.0, 1.5, -2.0))
    |> Assert.True

[<Fact>]
let ``Computing the magnutide of vector(1, 0, 0)`` () =
    let v = Tuple3d.Vector (1.0, 0.0, 0.0)
    let magnitudeV = Tuple.Magnitude(v);

    magnitudeV = 1.0
    |> Assert.True

[<Fact>]
let ``Computing the magnitude of vector(0, 1, 0)`` () =
    let v = Tuple3d.Vector (0.0, 1.0, 0.0)
    let magnitudeV = Tuple.Magnitude (v)

    magnitudeV = 1.0
    |> Assert.True

[<Fact>]
let ``Computing the magnitude of vector(0, 0, 1)`` () =
    let v = Tuple3d.Vector (0.0, 0.0, 1.0)
    let magnitudeV = Tuple.Magnitude (v)

    magnitudeV = 1.0
    |> Assert.True

[<Fact>]
let ``Computing the magnitude of vector(1, 2, 3)`` () =
    let v = Tuple3d.Vector (1.0, 2.0, 3.0)
    let magnitudeV = Tuple.Magnitude (v)

    magnitudeV = sqrt 14.0
    |> Assert.True

[<Fact>]
let ``Computing the magnitude of vector(-1, -2, -3)`` () =
    let v = Tuple3d.Vector (-1.0, -2.0, -3.0)
    let magnitudeV = Tuple.Magnitude (v)

    magnitudeV = sqrt 14.0
    |> Assert.True

[<Fact>]
let ``Normalizing vector(4, 0, 0) gives (1, 0, 0)`` () =
    let v = Tuple3d.Vector (4.0, 0.0, 0.0)
    let normalV = Tuple.Normalize(v)

    normalV = Tuple3d.Vector (1.0, 0.0, 0.0)
    |> Assert.True

[<Fact>]
let ``Normalizing vector(1, 2, 3)`` () =
    let v = Tuple3d.Vector (1.0, 2.0, 3.0)
    let normalV = Tuple.Normalize(v)

    normalV = Tuple3d.Vector (0.26726, 0.53452, 0.80178)
    |> Assert.True

[<Fact>]
let ``The magnitude of a normalized vector`` () =
    let v = Tuple3d.Vector (1.0, 2.0, 3.0)
    let normalV = Tuple.Normalize(v)

    Tuple.Magnitude (normalV) = 1.0
    |> Assert.True

[<Fact>]
let ``The dot product of two tuples`` () =
    let a = Tuple3d.Vector (1.0, 2.0, 3.0)
    let b = Tuple3d.Vector (2.0, 3.0, 4.0)
    let dotProduct = Tuple.DotProduct(a, b)

    dotProduct = 20.0
    |> Assert.True

[<Fact>]
let ``The cross product of two vectors`` () =
    let a = Tuple3d.Vector (1.0, 2.0, 3.0)
    let b = Tuple3d.Vector (2.0, 3.0, 4.0)
    let crossProductAB = Tuple3d.CrossProduct(a.Data, b.Data)
    let crossProductBA = Tuple3d.CrossProduct(b.Data, a.Data)

    crossProductAB = Tuple3d.Vector (-1.0, 2.0, -1.0)
    |> (&&) (crossProductBA = Tuple3d.Vector (1.0, -2.0, 1.0))
    |> Assert.True
