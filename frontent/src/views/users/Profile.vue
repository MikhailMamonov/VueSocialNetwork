<template>
<div class="row"> 
<div class="col-sm-3 well text-center">
  <Spinner v-bind:show="isBusy" />
    <div class="well">
            <p><a asp-controller="Users" asp-action="AccountDetails" asp-route-id="@Model.Id"><strong>{{profile.firstName}} {{profile.lastName}}</strong></a></p>
        </div>
        <div class="well">
            <p><a href="#"><strong>Interests</strong></a></p>
            <p>
                @Html.Partial("_UserInterests", Model.Interests)
            </p>
        </div>
</div>
 </div>
</template>

<script >
import Spinner from '@/components/Spinner.vue'; // @ is an alias to /src
import { mapGetters } from 'vuex';
import { dashboardService } from '../../services/dashboard.service';

export default {
    name: 'Profile',
    data: function () {
    return { 
      isBusy: false,
      user:{}
       };  
  },
  methods:{
      name() {
      return this.homeData.firstName + ' ' + this.homeData.lastName;
  }
  },
  computed: mapGetters({
    profile: 'user/profile',
  }),

  components: {
    Spinner,
  },
  
  created() {
     this.isBusy = true;
     dashboardService.getHomeDetails().then((resp) => {
        this.homeData = resp.data;
        this.isBusy = false;
     });
  }
}
</script>