using Microsoft.AspNetCore.Mvc;  
using TrainingApi.Features.TodoItem;

namespace TrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoItemsController(ITodoService todoService )
        {
            _todoService = todoService;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult> GetTodoItems()
        {
            var list = await _todoService.GetAllTodoItems();

            var data = new TodoResponseModalList()
            {
                IsSuccess = true,
                Message = "this is all items",
                TodoItems = list
            };
            return Ok(data); 
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
           var model = await _todoService.GetById(id);
            var data = new TodoResponseModal();
            if(model == null)
            {
                data.IsSuccess = false;
                data.Message = "item not found";
                return Ok(data);
            }
            data.IsSuccess = true;
            data.Message = "item found";
            data.TodoItem = model;
            return Ok(data);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
             var save = await _todoService.EditTodo(id, todoItem);
            var data = new TodoResponseModal();
            if(save==false)
            {
                data.IsSuccess = false;
                data.Message = "fail to update something went wrong";
            }
            data.IsSuccess = true;
            data.Message = "updated successfully";
            return Ok(data);
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CreateATodo([FromBody]TodoItem todoItem)
        {  
                var result = await _todoService.CreateATodo(todoItem);
                string message = result  ? "Saving Success" : "Saving Failed.";
                var data = new TodoResponseModal()
                {
                    IsSuccess = result,
                    Message = message,
                };
                return Ok(data);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var result = await _todoService.DeleteById(id);
            var data = new TodoResponseModal();
            if(result==false)
            {
                data.IsSuccess = false;
                data.Message = "failed to delete the item";
                return Ok(data);
            }


            data.IsSuccess = true;
            data.Message = "deleted successfully";
            return Ok(data);


        }

      /*  private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }*/
    }
}
