<template>
  <!-- <div class="card text-bg-dark  card-style col-3"> -->
  <div v-if="keep" class="keep" :class="{ show }">
    <img :src="keep.img" class="elevation-4 card-image" alt="..." @load="show = true">
    <div class="card-img-overlay d-flex flex-column justify-content-between content-style pe-0 no-pad">
      <div class="click-height" data-bs-toggle="modal" data-bs-target="#keepModal" @click="setActiveKeep(keep?.id)">
      </div>
      <div class="d-flex justify-content-between align-items-center">
        <h5 class="card-title text-light text-shadow">{{ keep.name }}</h5>
        <router-link :to="{ name: 'Profile', params: { profileId: keep.creator.id } }">
          <img class="profile-style display-none ms-5 pe-0" :src="keep.creator.picture" alt="" height="500" width="500"
            :title="keep.creator.name">
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
import { computed, ref } from "vue";
import { AppState } from "../AppState.js";


export default {
  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup() {
    return {
      show: ref(false),
      profile: computed(() => AppState.profile),
      account: computed(() => AppState.account),
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

.keep {
  opacity: 0;
  transition: opacity .3s ease;
  background-color: rgba(0, 0, 0, 0.151);

  &.show {
    opacity: 1;
  }
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
    height: 95%;
    cursor: pointer;
    width: 110%;
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

  .click-height {
    height: 95%;
    cursor: pointer;
    width: 100%;
    padding-left: 0;
  }

  .card-title {
    padding-left: 1.5vw;
  }

  .no-pad {
    padding: 0 !important;
  }

}
</style>