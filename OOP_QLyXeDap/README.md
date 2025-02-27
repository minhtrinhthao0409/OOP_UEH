
Một cửa hàng bán xe đạp có các đối tượng sau cần quản lý: 
Xe đạp thường, xe đạp đua, xe đạp địa hình, với:

UsualBicycle (id, color, price, utility),
SpeedBicycle (id, color, price, speedrate), 
ClimpBicycle (id, color, price, climprate).

Trong đó, id, color, price lần lượt là mã, màu, giá của xe; utility là phụ 
kiện tích hợp (yes/no), speedrate là số bước tăng tốc, 
speedclimp là số bước leo dốc.

1/ Xây dựng một lớp ABicycle dưới dạng lớp abstract
để tạo bộ khung dùng chung có các phương thức: Print, 
MakeDeal(id) để in thông tin và giảm giá theo mã.

2/ Cài đặt các lớp UsualBycycle, SpeedBicycle, ClimpBicycle

3/ Tạo một lớp Store chứa một List<ABicycle> và tạo 
ngẫu nhiên 10 xe thuộc ba nhóm nói trên. Lớp Store cung
cấp các phương thức sau:

- Tìm kiếm xe theo bước giá (from - to)
- Sắp xếp một danh sách xe theo tuỳ chọn (tăng/giảm) giá

4/ Cài đặt chương trình chính Main để thực thi kq.
