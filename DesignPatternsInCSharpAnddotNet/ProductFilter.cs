using System.Collections.Generic;

namespace DesignPatternsInCSharpAnddotNet
{
    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
            {
                if (product.Size == size)
                {
                    yield return product; // yield return 一次返回一个元素 然后保存现场 再次调用时会从现场继续执行
                }
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
            {
                if (product.Color == color)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var product in products)
            {
                if (product.Color == color && product.Size == size)
                {
                    yield return product;
                }
            }
        }
    }
}