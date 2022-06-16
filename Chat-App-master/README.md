אהלן!
הנחיות לבדיקת התרגיל:
ראשית יש לפתוח חלון של visual studio ולעשות clone לרפוזיטורי הנוכחי.
בתוך הפרויקט שנפתח, בעמודה השמאלית איפה שהsolution, יש להיכנס ל Chat-App.sln.
לאחר מכן ניתן להריץ את השרת. השרת ירוץ בכתובת localhost:5287, והדף שיפתח הוא עמוד הדירוגים של האפליקציה. ניתן לבחון אותו כעת אך יש קישור אליו גם מתוכנת הלקוח.

כעת יש להיכנס בחשבון הגיט הזה (Yosef-Perelman) לרפוזיטורי react-api (צירפתי אותכם כcollaborator גם אליו. זה בעצם התרגיל הראשון, שעבר התאמה לעבוד מול השרת).
לאחר שנכנסים צריך לעשות clone לרפוזיטורי לתוך פרויקט בvscode.
אחרי שעושים clone, צריך בטרמינל לרשום את הפקודה cd react-api כדי להיכנס לתיקיה.
לאחר מכן יש לרשום את הפקודות הבאות: <br />
npm install <br />
npm install react-router-dom <br />
npm install react-bootstrap <br />
npm install @microsoft/signalr <br />
ואז npm start ותוכנת הלקוח תעלה.
כעת ניתן להשתמש בה, והיא מסונכרנת עם השרת.

אם יש בעיות בהתקנה אשמח אם תפנו: 
יוסף פרלמן 054-2342099 yosefper@gmail.com
או לאריאל מנטל arielhy11@gmail.com

הערות:
1. הservices בשרת עובדים מול משתנים סטטיים ולא מול db.
2. כאשר מוסיפים איש קשר יש לרשום בserver את הכתובת: localhost:5287. (בנוסף, לא תמכנו באופציה של הוספת כינוי אלא הפכנו את שם איש הקשר לכינוי).
3. הסבר קצר על התרגיל (לא כולל הrate שעליו אין מה להסביר, הוא בדיוק כמו בהנחיות): יצרנו חמישה מודלים - contact, user, message, invitations ו-transfer, כאשר כולם עובדים מול services ולכולם למעט message יש controllers. קוד הריאקט מהתרגיל הראשון עבר התאמה והוא משמש כview.
4. מבחינת כתובות api, אנחנו הבנו שבחלק מהכתובות ניתן להוסיף את המשתמש הנוכחי לכתובת הurl (למעט invitations ו-transfer שבהם נאמר לא לשנות בכלל). בחלק מהapi הנוספים שיש בתרגיל תמכנו, אך באלה שהתנגשו עם api שבהם רצינו לעשות api עם שם משתמש בחרנו באופציה השנייה.
בכל מקרה בתוכנת הלקוח כל הapi's מעודכנים ופעולת האפליקציה מתנהלת בצורה זורמת.
להלן רשימת הapi שהשרת תומך בהם (איפה שלא מצוין, התוכן בbody הוא בדיוק כמו שמובא בדוגמאות שבתרגיל): 


1.	בקשת כל אנשי הקשר של כל המשתמשים (get): http://foo.com/api/contacts

2.	בקשת כל אנשי הקשר של משתמש מסוים (get): http://foo.com/api/contacts/{username}

3.	יצירת איש קשר בלי לציין מי המשתמש (post): http://foo.com/api/contacts

4.	יצירת איש קשר עבור משתמש מסוים (post): http://foo.com/api/contacts/{username}

5.	בקשת פרטי איש קשר של משתמש מסוים (get): http://foo.com/api/contacts/{username}/{contactname}

6.	עדכון פרטים של איש קשר עבור משתמש מסוים (put): http://foo.com/api/contacts/{username}/{contactname}

7.	מחיקת איש קשר עבור משתמש מסוים (delete): http://foo.com/api/contacts/{username}/{contactname}

8.	קבלת כל ההודעות של איש קשר מסוים ששייך למשתמש ספציפי (get): http://foo.com/api/contacts/{username}/{contactname}/messages

9.	קבלת פרטים (get) / מחיקה (delete) / ועדכון (put) של הודעה מסוימת של איש קשר מסוים: http://foo.com/api/contacts/{contactname}/messages/{messagenumber}

10.	הוספת הודעה לאיש קשר מסוים (post): http://foo.com/api/contacts/{username}/{contactname}/messages

11.	אימות התחברות (post): http://foo.com/api/users
בbody צריך לשלוח json עם {Id, Password}

12.	הרשמה (post): http://foo.com/api/users/register
בbody צריך לשלוח json עם {Id, Password}

13.	קבלת כל המשתמשים שקיימים בשרת (get): http://foo.com/api/users

14.	הזמנה לשיחה חדשה (post): http://foo.com/api/invitations

15.	הודעה חדשה עבור אחד המשתמשים (post): http://foo.com/api/transfer

