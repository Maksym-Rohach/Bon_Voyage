export default class CommentsChartService {
  static getComments() {
    return new Promise((resolve, reject) => {
      let data = getCommentsData();
      data ? resolve(data) : reject('Error');
    })
  }
}

function getRandomInt(min, max) {
  let rand = min + Math.random() * (max + 1 - min);
  return Math.floor(rand);
}

function getCommentsData() {
  let size = 0;
  let comment = [];
  let date = [];
  for (let i = 0; i < 12; i++) {
    comment[i] = getRandomInt(50, 100);
    size += comment[i];
    date[i] = (i+1)+'.01.2020';
  }

  let data = {
    comment: comment,
    date: date,
    size: size
  }
  return data;
}
