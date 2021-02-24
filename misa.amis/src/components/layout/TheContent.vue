<template>
  <div id="content">
    <EmployeeList />
  </div>
</template>

<script>
import EmployeeList from '../page/Employee/EmployeeList'

export default {
  name: 'Content',
  props: {

  },
  components: {
    EmployeeList,
  },
  data() {
    return {

    }
  },
  methods: {
    
  },
  computed: {

  },
}
</script>

<style scoped>
#content {
  background-color: #ececec;
  position: absolute;
  top: 50px;
  left: 200px;
  height: calc(100vh - 50px);
  width: calc(100% - 200px);
}
</style>