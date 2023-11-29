using System;
using Microsoft.AspNetCore.Mvc;

namespace Test4.Models
{
    public interface ICrudController<T>
    {
        Task<IActionResult> Index();
        Task<IActionResult> Details(int? id);
        IActionResult Create();
        Task<IActionResult> Create(T model);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, T model);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
    }
}

