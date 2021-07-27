<template>
  <b-card title="Skill chart">
    <b-card img-bottom>
      <ChartBarBase :chart-data="chartData" />
    </b-card>
  </b-card>
</template>

<script>
import ChartBarBase from "@/Chartjs/ChartBarBase";
import SkillService from '@/APIServices/SkillService'

export default {
  components: {
    ChartBarBase
  },
  data() {
    return {
      chartData:null,
      chartlabel:["csharp", "html", "css", "sqlserver", "vuejs", "postgressql", "javascript"],
    };
  },
  mounted() {
    this.fillData();
    
  },
  methods: {
    fillData() {
      SkillService.getSkillName()
        .then((resp) => {
            console.warn(resp.data)
      SkillService.getSkillInventory()
        .then((resp1) => {
            this.chartData = resp1.data
            console.warn(resp1.data)
        this.chartData = {
          labels: resp.data,
          datasets: [
            {
              backgroundColor: ["#47b6a0","#d750dc","#b38921","#1795cf","#7df3c2","#0c2369","#112912","#4b86e1","#fbcc71","#851abc",],
              borderColor: "#0c0306",
              data: resp1.data,
              label: "Inventory"
            }
          ]
        };
        })  
      }) 
    }
  }
};
</script>