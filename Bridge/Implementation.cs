namespace Bridge
{
    public abstract class Menu
    {
        public readonly ICoupon _coupon = null!;
        public abstract int CalculatePrice();

        public Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }
    }

    public class VegetarianMenu : Menu
    {
        public VegetarianMenu(ICoupon coupon) : base(coupon) { }

        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    public class NonVegMenu : Menu
    {
        public NonVegMenu(ICoupon coupon) : base(coupon) { }

        public override int CalculatePrice()
        {
            return 40 - _coupon.CouponValue;
        }
    }

    public interface ICoupon
    {
        int CouponValue { get; }
    }

    public class NoCoupon : ICoupon
    {
        public int CouponValue { get => 0; }
    }

    public class OneRupeeCoupon : ICoupon
    {
        public int CouponValue { get => 1; }
    }

    public class TwoRupeeCoupon : ICoupon
    {
        public int CouponValue { get => 2; }
    }


}