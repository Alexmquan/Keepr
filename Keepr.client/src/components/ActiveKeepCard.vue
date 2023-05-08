<template>
  <div class="row modal-size" v-if="activeKeep">
    <div class="col-md-6 picture-size"
      :style="{ backgroundImage: `url(${activeKeep.img})`, backgroundPosition: 'center', backgroundSize: 'cover' }">
      <!-- <img :src="activeKeep.img" alt=""> -->
    </div>
    <div class="col-md-6">
      <div class="d-flex justify-content-between flex-column  content-size">
        <div class="d-flex justify-content-center mt-3 row">
          <div class="col-4"></div>
          <div class="col-4 d-flex justify-content-center align-items-center">
            <h4>
              <i class="mdi mdi-eye"></i>
              {{ activeKeep.views }}
            </h4>
            <h4 class="ms-3">
              <i class="mdi mdi-alpha-k-box-outline"></i>
              {{ activeKeep.kept }}
            </h4>

          </div>
          <div class="col-4 d-flex justify-content-end align-items-center"><i v-if="account.id == activeKeep.creatorId"
              class="mdi mdi-delete-outline me-4 trashcan selectable fs-4" title="Delete Keep"
              @click="deleteKeep(activeKeep.id)"></i>
          </div>
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
import Pop from "../utils/Pop.js";
import { keepsService } from "../services/KeepsService.js";
import { logger } from "../utils/Logger.js";

export default {
  setup() {
    return {
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),

      async deleteKeep(keepId) {
        try {
          logger.log('test')
          if (Pop.confirm("Are you sure you want to delete this Keep?")) {
            await keepsService.deleteKeep(keepId);

          }
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.trashcan {
  color: rgb(237, 94, 94);

}

@media screen and (min-width: 768px) {
  .modal-size {
    height: 60vh;
    // width: 60vw;
  }

  .picture-size {

    border-bottom-left-radius: 8px;
    border-top-left-radius: 8px;
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
    border-bottom-left-radius: 8px;
    border-top-left-radius: 8px;
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