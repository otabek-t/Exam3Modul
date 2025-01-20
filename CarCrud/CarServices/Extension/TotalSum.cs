using CarServices.Dtos;

namespace CarServices.Extension;

public static class TotalSum
{
    public static void TotalSumma(List<CarDto> list)
    {
        var total = 0d;
        foreach (var item in list)
        {
            total += item.Price;
        }
        
    }
}
