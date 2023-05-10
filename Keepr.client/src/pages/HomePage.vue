<template>
  <div class="container-fluid">
    <!-- SECTION Keeps Cards -->
    <section class="main-cont mt-5">
      <div class="card card-style mb-5 rounded" v-for="k in keeps" :id="k.id">
        <KeepCard :keep="k" />
      </div>

    </section>
  </div>
  <LargeModal id="keepModal">
    <!-- <template #header>
      <div>Edit your Account</div>
    </template> -->
    <template #body>
      <ActiveKeepCard />
    </template>
  </LargeModal>
</template>

<script>
import { computed, onMounted } from "vue";
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
import KeepCard from "../components/KeepCard.vue";
import { AppState } from "../AppState.js";

export default {
  setup() {
    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      getKeeps();
    });
    return {
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepCard }
}
</script>

<style scoped lang="scss">
.card {
  --bs-card-bg: none !important;
  --bs-card-border-width: 0px;
}

@media screen and (min-width: 768px) {

  .main-cont {
    width: 80vw;
    margin: 0px auto;
    columns: 4;
    column-gap: 10vh;

  }


  .card-image {
    width: 18vw;
    object-fit: contain;
    border-radius: 8px;
  }

  // .image-style {
  //   width: 18vw;
  //   object-fit: contain;
  //   height: 100%;
  // }

  .card-style {
    transition: all .2s ease-in-out;
  }

  .card-style:hover {
    // width: 20vw;
    // padding: 20px;
    // margin-bottom: ;
    transform: scale(1.04);
  }

}

@media screen and (max-width: 768px) {
  .main-cont {
    width: 90vw;
    margin: 0px auto;
    columns: 2;
    column-gap: 2vh;
    margin-bottom: 10vh;

  }



}
</style>
