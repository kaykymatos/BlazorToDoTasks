using BlazorToDoTasks.Client.Util;
using BlazorToDoTasks.Client.ViewModels;

namespace BlazorToDoTasks.Client.Services
{
    public class ToDoTasksService : IToDoTasksService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath="/api/v1/tasks";
        public ToDoTasksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ErrorResponseViewModel>> CreateTask(TaskViewModel model)
        {
            var response =await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return await response.ReadContentAs<List<ErrorResponseViewModel>>();
            else
                return null;
        }

        public async Task<List<ErrorResponseViewModel>> DeleteTask(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return await response.ReadContentAs<List<ErrorResponseViewModel>>();
            else
                return null;
        }

        public async Task<List<TaskViewModel>> GetAllTasks()
        {
            var response = await _httpClient.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<List<TaskViewModel>>();
            else
                return [];
        }

        public async Task<TaskViewModel> GetTaskById(int id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<TaskViewModel>();
            else
                return new TaskViewModel();
        }

        public async Task<bool> UpdateTask(TaskViewModel model)
        {
            var response = await _httpClient.PutAsJson(BasePath, model);
            return response.IsSuccessStatusCode;
        }
    }
}
