export default class PersonsChartService {
    static getPersons(model){
        return new Promise((resolve, reject) => {
            let data = getPersonsData();
            data ? resolve(data) : reject('Error');
          })
    }
}

function getRandomInt(min,max) {
  let rand = min + Math.random() * (max + 1 - min);
  return Math.floor(rand);
}

function getPersonsData() {
  let size = getRandomInt(120, 240);
  let data = {
    gender: getGendersData(size),
    date: getAgeData(size),
    size: size
  }
  return data;
}

function getGendersData(size) {
  let gender = [];
  let man = 0;
  let women = 0;
  let tmp = -1;
  for (let i = 0; i < size; i++) {
    tmp = getRandomInt(0, 1);
    if (tmp) { man++ }
    else { women++ }
  }
  gender.push(man);
  gender.push(women);
  return gender;
}

function getAgeData(size) {
  let age = [];
  let age18 = 0;
  let age25 = 0;
  let age40 = 0;
  let age50 = 0;
  let age65 = 0;
  let age66 = 0;
  let tmp = -1;
  for (let i = 0; i < size; i++) {
    tmp = getRandomInt(1, 90);
    if (tmp <=18) { age18++ }
    else if (tmp > 18 && tmp <=25) { age25++}
    else if (tmp > 25 && tmp <=40) { age40++}
    else if (tmp > 40 && tmp <=50) { age50++}
    else if (tmp > 50 && tmp <=65) { age65++}   
    else { age66++ }
  }
  age.push(age18);
  age.push(age25);
  age.push(age40);
  age.push(age50);
  age.push(age65);
  age.push(age66);
  return age;
}
  