import{_ as u,o as m,c as f,K as k,a as e,b as r,F as d,r as v,d as t,w as g,k as K,P as C,e as o,f as s,A as h}from"./index.a3ca8da2.js";const y={setup(){async function a(){try{await K.getKeeps()}catch(n){C.error(n)}}return m(()=>{a()}),{keeps:f(()=>h.keeps)}},components:{KeepCard:k}},x={class:"container-fluid"},A={class:"main-cont mt-5"},M=["id"];function P(a,n,b,p,w,B){const _=o("KeepCard"),i=o("ActiveKeepCard"),l=o("LargeModal");return s(),e(d,null,[r("div",x,[r("section",A,[(s(!0),e(d,null,v(p.keeps,c=>(s(),e("div",{class:"card card-style mb-5 rounded",id:c.id},[t(_,{keep:c},null,8,["keep"])],8,M))),256))])]),t(l,{id:"keepModal"},{body:g(()=>[t(i)]),_:1})],64)}const $=u(y,[["render",P],["__scopeId","data-v-8c778650"]]);export{$ as default};
