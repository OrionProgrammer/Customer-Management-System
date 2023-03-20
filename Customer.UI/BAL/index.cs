using Microsoft.AspNetCore.Components;

namespace Customer.UI.BAL
{

    public class index : ComponentBase
    {

        [Inject]
        protected ICustomerDetailsService _customerDetailsService { get; set; }

        public List<CustomerDetailsModel> customers = new List<CustomerDetailsModel>();

        [Inject]
        private NavigationManager navManager { get; set; }

        protected override async Task<Task> OnInitializedAsync()
        {
            await LoadCustomers();

            return base.OnInitializedAsync();
        }

        //load customers from database
        private async Task LoadCustomers()
        {
            IEnumerable<CustomerDetailsModel> c = await _customerDetailsService.GetAll();
            customers = c.ToList();
        }


        public async Task Delete(int id)
        {
            await _customerDetailsService.Delete(id);
            await LoadCustomers();
        }

        public void Edit(int id)
        {
            navManager.NavigateTo("customer/" + id);
        }

        public void New()
        {
            navManager.NavigateTo("customer/0");
        }

    }
}
