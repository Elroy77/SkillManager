<template>
  <b-card title="Position chart">
    <b-card img-bottom>
      <ChartBarBase :chart-data="chartData" />
    </b-card>
  </b-card>
</template>

<script>
import ChartBarBase from "@/Chartjs/ChartBarBase";
import EmployeeService from '@/APIServices/EmployeeService';

export default {
  components: {
    ChartBarBase
  },
  data() {
    return {
      chartData: null
    };
  },
  mounted() {
    this.fillData();
  },
  methods: {
    fillData() {
      EmployeeService.getValuePosition()
        .then((resp) => {
            console.warn(resp.data)
        this.chartData = {
          labels: ["Manager","Developer","Designer","Tester","Analytical"],
          datasets: [
            {
              backgroundColor: ["#47b6a0","#d750dc","#b38921","#1795cf","#7df3c2","#0c2369","#112912","#4b86e1","#fbcc71","#851abc",],
              borderColor: "#0c0306",
              data: resp.data,
              label: "Inventory"
            }
          ]
        };
      }) 
    }
  }
};
</script>