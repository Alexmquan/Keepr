<template>
  <div class="row modal-size" v-if="activeKeep">
    <div class="col-md-6 picture-size"
      :style="{ backgroundImage: `url(${activeKeep.img})`, backgroundPosition: 'center', backgroundSize: 'cover' }">
      <!-- <img :src="activeKeep.img" alt=""> -->
    </div>
    <div class="col-md-6">
      <div class="d-flex justify-content-between flex-column  content-size">
        <div class="d-flex justify-content-center mt-3">
          <h4>
            <i class="mdi mdi-eye"></i>
            {{ activeKeep.views }}
          </h4>
          <h4 class="ms-3">
            <i class="mdi mdi-alpha-k-box-outline"></i>
            {{ activeKeep.kept }}
          </h4>
        </div>
        <div class="px-3">
          <h3 class="text-center">{{ activeKeep.name }}</h3>
          <p>{{ activeKeep.description }}</p>
        </div>
        <div class="d-flex justify-content-between align-items-center px-3 pb-3">
          <form @submit.prevent="addToVault">
            <div class="d-flex">
              <select class="form-select form-select-sm" aria-label=".form-select-sm example">
                <option selected>Open this select menu</option>
                <option value="1">One</option>
                <option value="2">Two</option>
                <option value="3">Three</option>
              </select>
              <button class="btn btn-info selectable ms-3">Save</button>
            </div>
          </form>

          <div class="d-flex align-items-center">
            <router-link :to="{ name: 'Profile', params: { profileId: activeKeep.creator.id } }">
              <img class="creator-image" :src="activeKeep.creator.picture" alt="creators image"
                :title="activeKeep.creator.name">
            </router-link>
            <h6 class="ps-2"> {{ activeKeep.creator.name }}</h6>
          </div>

        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {
    return {
      activeKeep: computed(() => AppState.activeKeep)
    }
  }
}
</script>


<style lang="scss" scoped>
@media screen and (min-width: 768px) {
  .modal-size {
    height: 50vh;
    // width: 60vw;
  }

  .content-size {
    height: 100%;
  }

  .creator-image {
    height: 4vh;
    width: 4vh;
    border-radius: 50%;
  }
}

@media screen and (max-width: 768px) {
  .modal-size {
    height: 95vh;
    width: 100vw;
  }

  .picture-size {
    height: 50%;
    width: 90vw;
  }

  .content-size {
    height: 100%;
  }

  .creator-image {
    height: 4vh;
    width: 4vh;
    border-radius: 50%;
  }
}
</style>