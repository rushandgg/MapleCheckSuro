# MapleCheckSuro
- 메이플스토리 길드컨텐츠 수로 점수 정산 프로그램<br/>
- 길드원 수로 점수 표시하는 부분이 Nexon API에서 제공하지 않음<br/>
- 인게임 내의 이미지를 업로드하면 텍스트로 인식하여 점수를 정산함<br/><br/>

- Program Language : C#<br/>
- Framework : .net framework 4.8 <br/>
- Using : Google.Cloud.Vision.V1 <br/>
<br/>

# 프로그램 사용 예시
#### 1. 메인화면
![1  메인화면](https://github.com/rushandgg/MapleSuro/assets/60992415/5e522a18-ba7c-47b7-ab6e-c8c930aac268)
<br/>
<br/>
#### 2. 본캐 부캐 입력창
![2  본캐부캐입력창](https://github.com/rushandgg/MapleSuro/assets/60992415/8e1aff8d-0bb6-474a-9ad5-c0b5d68a4382)
<br/>
<br/>
#### 3. 본캐 부캐 입력 예시
![3  본캐부캐입력예시](https://github.com/rushandgg/MapleSuro/assets/60992415/a6ba4ecb-4fe7-4a24-a214-eda969bd2d2f)
<br/>
<br/>
#### 4. 캐릭터, 점수 이미지 입력 예시
![4  이미지 업로드 예시](https://github.com/rushandgg/MapleSuro/assets/60992415/68f265a4-6f37-4f95-8777-ceb6c3e76b9e)
<br/>
<br/>
#### 5. 이미지 텍스트 변환 예시
![5  이미지 텍스트 변환 예시](https://github.com/rushandgg/MapleSuro/assets/60992415/78c1c968-4b15-40c1-8c85-c59afa040084)
<br/>
<br/>
#### 6. 점수, 조각 정산 예시
![6  점수 조각 정산 예시](https://github.com/rushandgg/MapleSuro/assets/60992415/b2b3925f-1673-420f-8ba8-34230767ec0a)
<br/>
<br/>
# 업데이트 내역
#### 1.0.0
+ 프로그램 개발

#### 1.1.0
+ 입력된 이미지가 텍스트로 제대로 인식 안되는 부분 존재
+ 리벤슈타인 거리를 이용해 가장 유사한 캐릭터 이름으로 수정하는 코드 추가
