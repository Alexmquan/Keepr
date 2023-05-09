<template>
  <!-- <div class="card text-bg-dark  card-style col-3"> -->
  <div v-if="keep">
    <img :src="keep.img" class="elevation-4 card-image" alt="...">
    <div class="card-img-overlay d-flex flex-column justify-content-between content-style pe-0">
      <div class="click-height" data-bs-toggle="modal" data-bs-target="#keepModal" @click="setActiveKeep(keep?.id)">
      </div>
      <div class="d-flex justify-content-between align-items-center">
        <h5 class="card-title text-light text-shadow">{{ keep.name }}</h5>
        <router-link :to="{ name: 'Profile', params: { profileId: keep.creator.id } }">
          <img class="profile-style display-none ms-5 pe-0" :src="keep.creator.picture" alt="" :title="keep.creator.name">
        </router-link>
      </div>

    </div>

  </div>

  <!-- <LargeModal id="keepModal">
    <template #body>
      <ActiveKeepCard />
    </template>
  </LargeModal> -->
</template>


<script>
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
import LargeModal from "./LargeModal.vue";


export default {
  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup() {
    return {
      async setActiveKeep(keepId) {
        try {
          await keepsService.setActiveKeep(keepId);
        }
        catch (error) {
          Pop.error(error);
        }
      }
    };
  },
  components: { LargeModal, LargeModal }
}
</script>


<style lang="scss" scoped>
.profile-style {
  height: 5vh;
  width: 5vh;
  border-radius: 50%;


}

.text-shadow {
  text-shadow: 2px 2px 2px black;
}

@media screen and (min-width: 768px) {
  .card-image {
    width: 18vw;
    object-fit: contain;
    border-radius: 8px;
  }

  .click-height {
    height: 90%;
    cursor: pointer;
    width: 100%;
  }
}

@media screen and (max-width: 768px) {

  .card-image {
    width: 42vw;
    object-fit: contain;
    border-radius: 8px;
  }

  .display-none {
    display: none;
  }

}
</style>