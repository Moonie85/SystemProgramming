#include "pch.h"
#include <cmath>

#define DLL_EXPORT __declspec(dllexport)

extern "C"
{
    DLL_EXPORT double Add(double a, double b)
    {
        return a + b;
    }

    DLL_EXPORT double Subtract(double a, double b)
    {
        return a - b;
    }

    DLL_EXPORT double Multiply(double a, double b)
    {
        return a * b;
    }

    DLL_EXPORT double Divide(double a, double b)
    {
        // Проверка на деление на ноль
        if (b == 0.0)
        {
            // Возвращаем NaN безопасным способом
            return NAN;  
        }
        return a / b;
    }
}