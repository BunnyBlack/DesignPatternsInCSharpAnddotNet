using System;
using System.Collections.Generic;

namespace DesignPatternsInCSharpAnddotNet
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }

        public bool IsSatisfied(Product product)
        {
            return _color == product.Color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }

        public bool IsSatisfied(Product product)
        {
            return _size == product.Size;
        }
    }
    
    public class CombinationSpecification : ISpecification<Product>
    {
        private readonly ISpecification<Product>[] _specs;

        public CombinationSpecification(params ISpecification<Product>[] specs)
        {
            _specs = specs;
        } 
        

        public bool IsSatisfied(Product product)
        {
            foreach (var spec in _specs)
            {
                if (!spec.IsSatisfied(product))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }
}