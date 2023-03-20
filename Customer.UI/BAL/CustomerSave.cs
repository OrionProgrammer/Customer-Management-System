using Microsoft.AspNetCore.Components;


namespace Customer.UI.BAL
{

    public class CustomerSave : ComponentBase
    {

        [Inject]
        protected ICustomerDetailsService _customerDetailsService { get; set; }

        [Parameter]
        public int id { get; set; }
        public CustomerDetailsModel customerDetailsModel { get; set; }

        public string title { get; set; }

        [Inject]
        public NavigationManager navManager { get; set; }

        protected override async Task<Task> OnInitializedAsync()
        {
            await LoadCustomer();

            return base.OnInitializedAsync();
        }


        //save customer details
        public async Task HandleSubmit()
        {
            //check if we are in edit mode, then update, else create new customer
            if (customerDetailsModel != null && id > 0)
                await _customerDetailsService.Update(customerDetailsModel);
            else
                await _customerDetailsService.Create(customerDetailsModel);


            //navigate to customer list screen
            navManager.NavigateTo("/", true);
        }


        //load custoemr details
        private async Task LoadCustomer()
        {
            customerDetailsModel = new CustomerDetailsModel();

            if (id == 0)
            {
                //set screen for new customer
                title = "New Customer";
            }
            else
            {
                title = "Edit Customer";

                //fetch customer for editing
                customerDetailsModel = await _customerDetailsService.Get(id);
                id = customerDetailsModel.Id;
            }
        }

        public void Cancel()
        {
            navManager.NavigateTo("/");
        }

    }
}
