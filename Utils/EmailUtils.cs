namespace ChuyenDoiSoServer.Utils;
public static class EmailUtils
{
    private static readonly string HOME_PAGE_LINK = "<a style='color: #f80;text-decoration: none;' href='https://localhost:3000'>RaoVat.net</a>";

    public static (string, string) TaoMailKichHoat(ulong userId, string code)
    {
        var subject = "Xác nhận đăng ký tài khoản";
        var body = @$"
           <div style='
                padding: 30px;
                width: 90%;
                background-color: #e8e8e8;
            '>
    <div style='width: 500px; 
                    margin: 0 auto;
                    background-color: #fff;
                    border: 1px solid grey;
                    padding: 16px;'>
        <div style='display: flex; align-items: center; justify-content: center; font-size: 26px; font-family: Tahoma, Geneva, Verdana, sans-serif;'>
            <img src='https://raw.githubusercontent.com/TranQuyenSinh/Image-store/main/chuyendoiso_banner.jpg' width='100%' height='160' />
        </div>
        <div style='font-size: 20px; line-height: 40px; font-family: Arial, Tahoma, Geneva, Verdana, sans-serif;  text-align: center;'>
            <h2 style='font-weight:normal; '>
                <p> Cảm ơn bạn đã đăng ký thành viên của Cổng thông tin doanh nghiệp!</p>
            </h2>
            <p>
                Để kích hoạt tài khoản, bạn chỉ cần nhấn vào đây:
            </p>
            <p>
                <a style='padding: 12px 16px; color: white;background-color: #f80;text-decoration: none; font-weight: 600;' href='{Environment.GetEnvironmentVariable("ASPNETCORE_APPLICATION_URL")}/kich-hoat?userId={userId}&code={code}'>
                    Kích hoạt
                </a>
            </p>
        </div>
    </div>
</div>
            ";
        return (subject, body);
    }
}