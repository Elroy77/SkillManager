<template>
<div class="Overview">
  <div class="row">
    <div class="col-sm-6">
      <div class="grid">
        <SkillChart />
      </div>
    </div>
    <div class="col-sm-6">
      <div class="grid">
        <PositionChart />
      </div>
    </div>
  </div>
</div>

</template>

<script>
import SkillChart from "@/components/SkillChart";
import PositionChart from "@/components/PositionChart";

export default {
  components: {
    SkillChart,
    PositionChart,
  }
};
</script>

<style scoped>
.Overview {
  background-color: #f0f0f0;
}
</style>