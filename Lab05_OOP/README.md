# Lab05_OOP
1. Khai báo một interface IVector gồm có các phương thức:<br>
        - Add(IVector vector): IVector<br>
        - Subtract(IVector vector): IVector<br>
        - Multiply(double scalar): IVector<br>
        - Divide(double scalar): IVector<br>
        - Length(): double<br>
        - Normalize(): IVector<br>
        - DotProduct(IVector vector): double<br>
        - CrossProduct(IVector vector): IVector<br>
để thực thi các chức năng: cộng 2 vector, trừ 2 vector, nhân vector với một số, chia vector cho một số, tính độ dài vector, chuẩn hóa vector (chia từng thành phần cho độ dài của vector, tích vô hướng, tích có hướng.
2. Khai báo một lớp Vector2D và Vector3D kế thừa từ IVector và thực thi các phương thức của IVector.
3. Trong hàm main, tạo ra một List các IVector và triệu gọi hàm tạo của Vector2D và Vector3D ngẫu nhiên cho từng phần tử trong List. Sau đó triệu gọi các phương thức tương ứng của IVector cho từng phần tử trong List.
4. Cho phép Vector2D và Vector3D thực thi bổ sung 2 interface ICloneable và IComparable. Với IComeparable, các vector có thể so sánh với nhau dựa trên độ dài của nó (thông qua Length). Sắp xếp các vector trong List của câu 3 theo thứ tự tăng dần của độ dài. In ra dưới dạng bảng toạ độ các vector (x, y, z) và độ dài tương ứng.
5. Bổ sung vào lớp Vector2D một phương thức ConvertToVector3D() để chuyển đổi từ Vector2D sang Vector3D. Trong đó, có sử dụng đến phương thức Clone() để tạo ra một bản sao của Vector2D trước khi chuyển đổi.
