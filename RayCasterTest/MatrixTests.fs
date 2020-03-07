module MatrixTests

open System
open Xunit
open RayCasterEngine

[<Fact>]
let ``Constructing and inspecting a 4x4 matrix`` () =
    let m = array2D [[ 1.0;  2.0;  3.0;  4.0]
                     [ 5.5;  6.5;  7.5;  8.5]
                     [ 9.0; 10.0; 11.0; 12.0]
                     [13.5; 14.5; 15.5;  6.5]]
    let matrix = RayCasterEngine.Matrix m

    (matrix.Data.[0,0] = 1.0 &&
     matrix.Data.[0,3] = 4.0 &&
     matrix.Data.[1,0] = 5.5 &&
     matrix.Data.[1,2] = 7.5 &&
     matrix.Data.[2,2] = 11.0 &&
     matrix.Data.[3,0] = 13.5 &&
     m.[3,2] = 15.5)
     |> Assert.True

[<Fact>]
let ``A 2x2 matrix ought to be representable`` () =
    let m = array2D [[-3.0;  5.0]
                     [ 1.0; -2.0]]
    let matrix = RayCasterEngine.Matrix m

    (matrix.Data.[0,0] = -3.0 &&
     matrix.Data.[0,1] = 5.0 &&
     matrix.Data.[1,0] = 1.0 &&
     matrix.Data.[1,1] = -2.0)
     |> Assert.True

[<Fact>]
let ``A 3x3 matrix ought to be representable`` () =
    let m = array2D [[-3.0;  5.0;  0.0]
                     [ 1.0; -2.0; -7.0]
                     [ 0.0;  1.0;  1.0]]
    let matrix = RayCasterEngine.Matrix m
    (matrix.Data.[0,0] = -3.0 &&
     matrix.Data.[1,1] = -2.0 &&
     matrix.Data.[2,2] =  1.0)
    |> Assert.True

[<Fact>]
let ``Matrix equality with identical matrices`` () =
    let m1 = array2D [[1.0; 2.0; 3.0; 4.0]
                      [5.0; 6.0; 7.0; 8.0]
                      [9.0; 8.0; 7.0; 6.0]
                      [5.0; 4.0; 3.0; 2.0]]
    let m2 = array2D [[1.0; 2.0; 3.0; 4.0]
                      [5.0; 6.0; 7.0; 8.0]
                      [9.0; 8.0; 7.0; 6.0]
                      [5.0; 4.0; 3.0; 2.0]]
    let matrix1 = RayCasterEngine.Matrix m1
    let matrix2 = RayCasterEngine.Matrix m2

    matrix1 = matrix2 |> Assert.True

[<Fact>]
let ``Matrix equality with different matrices`` () =
    let m1 = array2D [[1.0; 2.0; 3.0; 4.0]
                      [5.0; 6.0; 7.0; 8.0]
                      [9.0; 8.0; 7.0; 6.0]
                      [5.0; 4.0; 3.0; 2.0]]
    let m2 = array2D [[2.0; 3.0; 4.0; 5.0]
                      [6.0; 7.0; 8.0; 9.0]
                      [8.0; 7.0; 6.0; 5.0]
                      [4.0; 3.0; 2.0; 1.0]]
    let matrix1 = RayCasterEngine.Matrix m1
    let matrix2 = RayCasterEngine.Matrix m2

    matrix1 <> matrix2 |> Assert.True

[<Fact>]
let ``Multiplying two matrices`` () =
    let m1 = array2D [[1.0; 2.0; 3.0; 4.0]
                      [5.0; 6.0; 7.0; 8.0]
                      [9.0; 8.0; 7.0; 6.0]
                      [5.0; 4.0; 3.0; 2.0]]
    let m2 = array2D [[-2.0; 1.0; 2.0;  3.0]
                      [ 3.0; 2.0; 1.0; -1.0]
                      [ 4.0; 3.0; 6.0;  5.0]
                      [ 1.0; 2.0; 7.0;  8.0]]
    let m3 = array2D [[20.0; 22.0; 50.0; 48.0]
                      [44.0; 54.0; 114.0; 108.0]
                      [40.0; 58.0; 110.0; 102.0]
                      [16.0; 26.0; 46.0; 42.0]]
    let matrix1 = RayCasterEngine.Matrix m1
    let matrix2 = RayCasterEngine.Matrix m2
    let matrix3 = RayCasterEngine.Matrix m3

    matrix1 * matrix2 = matrix3 |> Assert.True